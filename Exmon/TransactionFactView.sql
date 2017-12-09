CREATE view [dbo].[TransactionFactView] 
as 
select 
DateKey as DateAllKey,
UserKey,
AccountKey,
TransactionTypeKey,
TransactionId, 
Amount,
Comments,
FollowupInd,
CancelDateKey,
AmountBack,
AssetTypeKey,
AssetInd,
Amount - ISNULL(AmountBack, 0) as NetAmount
from TransactionFact