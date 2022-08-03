with GroupTypes as (select newid() [GUID], 'Public group' [Name]
					union select newid(), 'Private group'
					union select newid(), 'Public channel'
					union select newid(), 'Private channel')
insert into [dbo].[GroupType]
select [GUID], [Name]
from GroupTypes gt
where not exists (select 1
				  from dbo.[GroupType] gt1
				  where gt1.[Name] = gt.[name])