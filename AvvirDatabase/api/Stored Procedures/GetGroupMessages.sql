-- =============================================
-- Author:		Victor Klein 
-- Create date: 24.12.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE api.GetGroupMessages 
	-- Add the parameters for the stored procedure here
	@GroupGUID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if (@GroupGUID is null)
		throw 500007, 'Group GUID not specified', 1

	if(object_id('tempdb..#temp_messages') is not null)
		drop table #temp_messages

	select [GUID] as MessageGUID
			,AuthorGUID
			,ReceiverGUID
			,ReplyMessageGUID
			,MessageBody
	into #temp_messages
	from dbo.[Message]
	where GroupGUID = @GroupGUID

	select [GUID]
			,MessageGUID
			,AuthorGUID
			,ReceiverGUID
			,tm.MessageBody
			,m.MessageBody as ReplyMessageBody
	from #temp_messages tm
	left join dbo.[Message] m on m.[GUID] = tm.ReplyMessageGUID

END
