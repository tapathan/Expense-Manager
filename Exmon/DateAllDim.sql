create view DateAllDim as 
select DDLSS.DateKey DateAllKey, DDLSS.*, MEF.MajorEvent, MEF.HolidayInd from (select DDLS.*, SPF.SpecialPeriod from (select DDL.*, SF.Season from (select DD.*, LOC.UserKey, LOC.Location from DateDim DD,
(select FromDateKey, ToDateKey, GL.UserKey, L11.Location, L22.Location NextLocation
from LocationFact L11, (select * from LocationFact union select 9999999999, UserKey, '' from LocationFact) L22, 
(select L1.DateKey FromDateKey, MIN(L2.DateKey) ToDateKey, L1.UserKey from LocationFact L1, (select * from LocationFact union select 9999999999, UserKey, '' from LocationFact) L2 
where L2.DateKey != L1.DateKey and L2.DateKey > L1.DateKey and L1.UserKey = L2.UserKey
group by L1.DateKey, L1.UserKey) GL
where L22.DateKey != L11.DateKey and L22.DateKey > L11.DateKey
and L11.DateKey = FromDateKey and L22.DateKey = ToDateKey and L11.UserKey = GL.UserKey and L22.UserKey = GL.UserKey) LOC
where DD.DateKey >= LOC.FromDateKey and DD.DateKey < LOC.ToDateKey) DDL
left join SeasonFact SF on SF.DateKey = DDL.DateKey) DDLS
left join SpecialPeriodFact SPF on SPF.DateKey = DDLS.DateKey) DDLSS
left join MajorEventFact MEF on MEF.DateKey = DDLSS.Datekey