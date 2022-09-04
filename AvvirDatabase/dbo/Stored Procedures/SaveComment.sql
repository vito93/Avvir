


-- =============================================
-- Author:		Victor Klein
-- Create date: 04.09.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveComment]
	-- Add the parameters for the stored procedure here
	@AuthorGUID uniqueidentifier = NULL,
	@MessageGUID uniqueidentifier = NULL,
	@CommentBody nvarchar(1000) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	if(@AuthorGUID is null or @MessageGUID is null)
		throw 500007, 'Message or account not specified', 1

	if not exists(select 1 from dbo.Account where [GUID] = @AuthorGUID)
	or not exists(select 1 from dbo.[Message] where [GUID] = @MessageGUID)
		throw 500008, 'Message or account does not exist', 1

	if(@CommentBody is null)
		throw 500009, 'Empty comment body', 1

	insert into dbo.Comment(	MessageGUID
								,AuthorGUID
								,Body)
	select 	@MessageGUID
			,@AuthorGUID
			,@CommentBody

	commit

	end try
	begin catch
	    declare @error int, @message varchar(4000)
        select @error = error_number(), @message = error_message()
        rollback; 
        raiserror ('%s: %d: %s', 16, 1, @checkpoint, @error, @message) ;
	end catch
END