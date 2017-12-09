create view [dbo].[FromAccountDim] as 
select AccountKey as FromAccountKey, Description, Type, AccountNo, InitialAmount, StartDate, EndDate
from AccountDim


