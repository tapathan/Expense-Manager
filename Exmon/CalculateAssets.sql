CREATE PROC [dbo].[Calculate_Assets]
(
@_PassedDateKey INT
)
AS
DECLARE @v_NoOfDays DECIMAL(18,2)
DECLARE @v_NoOfWeeks DECIMAL(18,2)
DECLARE @v_NoOfMonths DECIMAL(18,2)
DECLARE @v_NoOfYears DECIMAL(18,2) 
DECLARE @v_DepRate DECIMAL(18,2) 
DECLARE @v_DepIntCnt DECIMAL(18,2) 
DECLARE @v_DepInt VARCHAR(20) 
DECLARE @v_TransactionId INT
DECLARE @v_DateKey INT
DECLARE @v_Amount DECIMAL(18,2)
DECLARE @v_ActDepRate DECIMAL(18,2)
DECLARE @C1 CURSOR
BEGIN
  DELETE FROM AssetCalculations
  SET @C1 = CURSOR FOR SELECT 
	    DateKey, TransactionId, DepreciationRate, DepreciationIntervalCount, DepreciationInterval, Amount 
	  FROM TransactionFact TF, AssetTypeDim ATD
	  WHERE TF.AssetTypeKey = ATD.AssetTypeKey 
	    AND TF.DateKey <= @_PassedDateKey AND TF.AssetInd = 'Y'
  OPEN @C1
  FETCH NEXT
  FROM @C1 INTO
    @v_DateKey, @v_TransactionId, @v_DepRate, @v_DepIntCnt, @v_DepInt, @v_Amount
  WHILE @@FETCH_STATUS = 0
  BEGIN
    SET @v_NoOfDays = @_PassedDateKey - @v_DateKey
    SET @v_NoOfWeeks = @v_NoOfDays / 7
    SET @v_NoOfMonths = @v_NoOfDays / 30
    SET @v_NoOfYears = @v_NoOfDays / 365
    -- IF DAYS
    IF (@v_DepInt = 'DAY' OR @v_DepInt = 'DAYS')
      WHILE (@v_NoOfDays > 0)
      BEGIN
        IF (@v_NoOfDays < 1)
          SET @v_ActDepRate = @v_DepRate * @v_NoOfDays
        ELSE 
          SET @v_ActDepRate = @v_DepRate
        SET @v_Amount = @v_Amount - (@v_ActDepRate * @v_Amount / 100)
        SET @v_NoOfDays = @v_NoOfDays - @v_DepIntCnt
      END
    -- IF WEEKS
    IF (@v_DepInt = 'WEEK' OR @v_DepInt = 'WEEKS')
      WHILE (@v_NoOfWeeks > 0)
      BEGIN
        IF (@v_NoOfWeeks < 1)
          SET @v_ActDepRate = @v_DepRate * @v_NoOfWeeks
        ELSE 
          SET @v_ActDepRate = @v_DepRate
        SET @v_Amount = @v_Amount - (@v_ActDepRate * @v_Amount / 100)
        SET @v_NoOfWeeks = @v_NoOfWeeks - @v_DepIntCnt
      END
    -- IF MONTHS
    IF (@v_DepInt = 'MONTH' OR @v_DepInt = 'MONTHS')
      WHILE (@v_NoOfMonths > 0)
      BEGIN
        IF (@v_NoOfMonths < 1)
          SET @v_ActDepRate = @v_DepRate * @v_NoOfMonths
        ELSE 
          SET @v_ActDepRate = @v_DepRate
        SET @v_Amount = @v_Amount - (@v_ActDepRate * @v_Amount / 100)
        SET @v_NoOfMonths = @v_NoOfMonths - @v_DepIntCnt
      END
    -- IF YEARS
    IF (@v_DepInt = 'YEAR' OR @v_DepInt = 'YEARS')
      WHILE (@v_NoOfYears > 0)
      BEGIN
        IF (@v_NoOfYears < 1)
          SET @v_ActDepRate = @v_DepRate * @v_NoOfYears
        ELSE 
          SET @v_ActDepRate = @v_DepRate
        PRINT 'v_ActDepRate = @v_ActDepRate'
        SET @v_Amount = @v_Amount - (@v_ActDepRate * @v_Amount / 100)
        SET @v_NoOfYears = @v_NoOfYears - @v_DepIntCnt
        PRINT 'v_NoOfYears = @v_NoOfYears'
      END
    -- INSERT IN ASSET CALC TABLE
    INSERT INTO AssetCalculations VALUES (@v_TransactionId, @v_Amount)
    FETCH NEXT
    FROM @C1 INTO
      @v_DateKey, @v_TransactionId, @v_DepRate, @v_DepIntCnt, @v_DepInt, @v_Amount
  END
END