create view [dbo].[ToAccountDim] as 
select AccountKey as ToAccountKey, Description, Type, AccountNo, InitialAmount, StartDate, EndDate
from AccountDim


