create view AccountBalanceFactView as 
select DD.DateKey, AOC.AccountKey, AOC.Amount from DateDim DD,
(select FromDateKey, ToDateKey, GA.AccountKey, A11.Amount, A22.Amount NextAmount
from AccountBalanceFact A11, 
  (select * from AccountBalanceFact union select 9999999999, AccountKey, 0 from AccountBalanceFact) A22,
(select A1.DateKey FromDateKey, MIN(A2.DateKey) ToDateKey, A1.AccountKey from AccountBalanceFact A1, 
  (select * from AccountBalanceFact union select 9999999999, AccountKey, 0 from AccountBalanceFact) A2 
where A2.DateKey != A1.DateKey and A2.DateKey > A1.DateKey and A1.AccountKey = A2.AccountKey
group by A1.DateKey, A1.AccountKey) GA
where A22.DateKey != A11.DateKey and A22.DateKey > A11.DateKey
and A11.DateKey = FromDateKey and A22.DateKey = ToDateKey and A11.AccountKey = GA.AccountKey and A22.AccountKey = GA.AccountKey) AOC
where DD.DateKey >= AOC.FromDateKey and DD.DateKey < AOC.ToDateKey