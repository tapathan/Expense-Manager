CREATE PROC CalculateAccountBal
(
@_PassedDateKey INT
)
AS
DECLARE @v_DateKey INT
DECLARE @v_MaxDateKey INT
DECLARE @v_AccountKey INT
DECLARE @v_PrevAccountKey INT
DECLARE @v_Amount DECIMAL(18,2)
DECLARE @v_PrevAmount DECIMAL(18,2)
DECLARE @C1 CURSOR
BEGIN
  DELETE FROM AccountBalanceFact WHERE DateKey >= @_PassedDateKey
  SET @C1 = CURSOR FOR SELECT DateKey, AccountKey, SUM(NetAmount) NetAmount FROM (
	  SELECT DateAllKey DateKey, AccountKey, TTD.CreditDebitInd, SUM(NetAmount) NetAmount
	    FROM TransactionFactView TFV, TransactionTypeDim TTD
	    WHERE TFV.DateAllKey >= @_PassedDateKey
	      AND TFV.TransactionTypeKey = TTD.TransactionTypeKey
	      AND TTD.CreditDebitInd = 'C'
	    GROUP BY DateAllKey, AccountKey, TTD.CreditDebitInd
	  UNION
	    SELECT DateAllKey DateKey, AccountKey, TTD.CreditDebitInd, SUM(NetAmount) * -1 NetAmount
	    FROM TransactionFactView TFV, TransactionTypeDim TTD
	    WHERE TFV.DateAllKey >= @_PassedDateKey
	      AND TFV.TransactionTypeKey = TTD.TransactionTypeKey
	      AND TTD.CreditDebitInd = 'D'
	    GROUP BY DateAllKey, AccountKey, TTD.CreditDebitInd
	  UNION 
	    SELECT DateKey, ToAccountKey AccountKey, 'C' CreditDebitInd, SUM(Amount) NetAmount
	    FROM AccountTransferFact
	    WHERE DateKey >= @_PassedDateKey
	    GROUP BY DateKey, ToAccountKey
	  UNION
	    SELECT DateKey, FromAccountKey AccountKey, 'D' CreditDebitInd, SUM(Amount) * 1 NetAmount
	    FROM AccountTransferFact
	    WHERE DateKey >= @_PassedDateKey
	    GROUP BY DateKey, FromAccountKey
	  ) A
	  GROUP BY DateKey, AccountKey
	  ORDER BY AccountKey, DateKey
  OPEN @C1
  FETCH NEXT
  FROM @C1 INTO
    @v_DateKey, @v_AccountKey, @v_Amount
  WHILE @@FETCH_STATUS = 0
  BEGIN
    IF (@v_PrevAccountKey IS NULL OR @v_AccountKey != @v_PrevAccountKey)
    BEGIN
      SELECT @v_MaxDateKey = ISNULL(MAX(DateKey), 0) FROM AccountBalanceFact WHERE AccountKey = @v_AccountKey
      SELECT @v_PrevAmount = ISNULL(MAX(Amount), 0) FROM AccountBalanceFact 
        WHERE DateKey = @v_MaxDateKey AND AccountKey = @v_AccountKey
    END
    SET @v_Amount = @v_PrevAmount + @v_Amount
    IF (@v_PrevAccountKey != @v_AccountKey OR @v_PrevAmount != @v_Amount)
      INSERT INTO AccountBalanceFact VALUES (@v_DateKey, @v_AccountKey, @v_Amount)
    SET @v_PrevAmount = @v_Amount
    SET @v_PrevAccountKey = @v_AccountKey
    FETCH NEXT
    FROM @C1 INTO
      @v_DateKey, @v_AccountKey, @v_Amount
  END
END
