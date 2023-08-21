

-- =============================================
-- Author:		Victor Klein
-- Create date: 20.08.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [api].[SaveMessage]
	-- Add the parameters for the stored procedure here
	@AuthorGUID uniqueidentifier = NULL,
	@ReceiverGUID uniqueidentifier = NULL,
	@GroupGUID uniqueidentifier = NULL,
	@ReplyMessageGUID uniqueidentifier = NULL,
	@MessageBody nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	if(@ReceiverGUID is null and @GroupGUID is null)
		throw 500002, 'No message destination specified', 1

	insert into dbo.[Message](AuthorGUID
								,ReceiverGUID
								,MessageBody
								,GroupGUID
								,ReplyMessageGUID
								,Created)
	select @AuthorGUID
			,@ReceiverGUID
			,@MessageBody
			,@GroupGUID
			,@ReplyMessageGUID
			,getdate()

	commit

	end try
	begin catch
	    declare @error int, @message varchar(4000)
        select @error = error_number(), @message = error_message()
        rollback; 
        raiserror ('%s: %d: %s', 16, 1, @checkpoint, @error, @message) ;
	end catch
END
