create view [dbo].[FormDimView] 
as select 
FormKey,
FrmName,	
'ALL' as Access,
FrmSize,	
FrmColor,	
FrmFont,	
Calculations
from FormDim


