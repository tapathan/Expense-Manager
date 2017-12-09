CREATE view [dbo].[AssetCalculatedFact] 
as select 
TF.AccountKey, 
TF.AssetTypeKey,
TF.Amount TransactionAmount,
TF.Comments,
TF.DateKey DateAllKey,
TF.TransactionTypeKey,
TF.UserKey,
AC.Amount Amount
from TransactionFact TF, AssetCalculations AC
where TF.TransactionId = AC.TransactionId