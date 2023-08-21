


-- =============================================
-- Author:		Victor Klein
-- Create date: 29.01.2023
-- Description:	Checks user registration token
-- =============================================
create PROCEDURE [api].[CheckConfirmationToken]
	-- Add the parameters for the stored procedure here
	@AccountGUID uniqueidentifier = NULL,
	@ConfirmationToken uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	if (not exists(select 1
					from dbo.Account
					where [GUID] = @AccountGUID)
	or
	not exists(SELECT 1
				from dbo.AccountConfirmationToken
				where [GUID] = @ConfirmationToken
				and IsUsed = 0
	))
		throw 500016, 'There is no such account or invalid token', 1

	DECLARE @email varchar(255) = (select top 1 email
									from dbo.Account
									where [GUID] = @AccountGUID)


	UPDATE dbo.AccountConfirmationToken
	set IsUsed = 1
	where [GUID] = @AccountGUID

	DECLARE @body varchar(255) = 'Account confirmed successfully'

	exec msdb.dbo.sp_send_dbmail @profile_name = 'dev',
						@recipients = @email,
						@subject = 'Avvir account confirmed',
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
