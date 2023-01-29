SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO



-- =============================================
-- Author:		Victor Klein
-- Create date: 29.01.2023
-- Description:	Confirms user registration
-- =============================================
CREATE PROCEDURE [api].[SendUserConfirmationMail]
	-- Add the parameters for the stored procedure here
	@AccountGUID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	if not exists(select 1
					from dbo.Account
					where [GUID] = @AccountGUID)
		throw 500014, 'There is no such account', 1

	DECLARE @email varchar(255) = (select top 1 email
									from dbo.Account
									where [GUID] = @AccountGUID),
	@tokenGUID UNIQUEIDENTIFIER

	DECLARE @outputTable TABLE (token uniqueidentifier)


	insert into dbo.AccountConfirmationToken(AccountGUID)
	output INSERTED.[GUID]
	into @outputTable
	select @AccountGUID
	
	set @tokenGUID = (select top 1 token from @outputTable)

	DECLARE @body varchar(255) = 'The confirmation token is: ' + cast(@tokenGUID as varchar)

	exec msdb.dbo.sp_send_dbmail @profile_name = 'dev',
						@recipients = @email,
						@subject = 'Confirm Avvir account email',
						@body = @body

	commit

	end try
	begin catch
	    declare @error int, @message varchar(4000)
        select @error = error_number(), @message = error_message()
        rollback; 
        raiserror ('%s: %d: %s', 16, 1, @checkpoint, @error, @message) ;
	end catch
END
GO