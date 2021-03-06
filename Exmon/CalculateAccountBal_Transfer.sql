CREATE TRIGGER CalculateAccountBal_Transfer
ON AccountTransferFact FOR INSERT, UPDATE, DELETE
AS 
BEGIN
DECLARE @v_DateKey INT
SELECT @v_DateKey = DateKey FROM INSERTED
IF @v_DateKey IS NULL
  SELECT @v_DateKey = DateKey FROM DELETED
EXEC CalculateAccountBal @v_DateKey
END