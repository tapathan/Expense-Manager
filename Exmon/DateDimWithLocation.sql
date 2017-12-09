select DD.DateKey, LOC.UserKey, LOC.Location, LOC.NextLocation from DateDim DD,
(select FromDateKey, ToDateKey, GL.UserKey, L11.Location, L22.Location NextLocation
from LocationFact L11, (select * from LocationFact union select 9999999999, UserKey, '' from LocationFact) L22, 
(select L1.DateKey FromDateKey, MIN(L2.DateKey) ToDateKey, L1.UserKey from LocationFact L1, (select * from LocationFact union select 9999999999, UserKey, '' from LocationFact) L2 
where L2.DateKey != L1.DateKey and L2.DateKey > L1.DateKey and L1.UserKey = L2.UserKey
group by L1.DateKey, L1.UserKey) GL
where L22.DateKey != L11.DateKey and L22.DateKey > L11.DateKey
and L11.DateKey = FromDateKey and L22.DateKey = ToDateKey and L11.UserKey = GL.UserKey and L22.UserKey = GL.UserKey) LOC
where DD.DateKey >= LOC.FromDateKey and DD.DateKey < LOC.ToDateKey
order by UserKey desc 