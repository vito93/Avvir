
-- =============================================
-- Author:		Victor Klein 
-- Create date: 24.12.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [api].[GetChatMessages] 
	-- Add the parameters for the stored procedure here
	@Account1GUID UNIQUEIDENTIFIER,
	@Account2GUID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if (@Account1GUID is null or @Account2GUID is null)
		throw 500006, 'One of the parties not specified', 1

	if(object_id('tempdb..#temp_messages') is not null)
		drop table #temp_messages

	select [GUID] as MessageGUID
			,AuthorGUID
			,ReceiverGUID
			,ReplyMessageGUID
			,MessageBody
	into #temp_messages
	from dbo.[Message]
	where (AuthorGUID = @Account1GUID or ReceiverGUID = @Account1GUID)
	and (AuthorGUID = @Account2GUID or ReceiverGUID = @Account2GUID)

	select [GUID]
			,MessageGUID
			,AuthorGUID
			,ReceiverGUID
			,tm.MessageBody
			,m.MessageBody as ReplyMessageBody
	from #temp_messages tm
	left join dbo.[Message] m on m.[GUID] = tm.ReplyMessageGUID

END