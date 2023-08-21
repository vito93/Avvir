


-- =============================================
-- Author:		Victor Klein
-- Create date: 29.01.2023
-- Description:	Gets an auth token for specified account
-- =============================================
create PROCEDURE [api].[GetAuthrizationToken]
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

	if (not exists(select 1
					from dbo.Account
					where [GUID] = @AccountGUID))
		throw 500017, 'There is no such account', 1

	insert into dbo.AuthorizationToken(AccountGUID)
	output inserted.[GUID]
	select @AccountGUID

	commit

	end try
	begin catch
	    declare @error int, @message varchar(4000)
        select @error = error_number(), @message = error_message()
        rollback; 
        raiserror ('%s: %d: %s', 16, 1, @checkpoint, @error, @message) ;
	end catch
END
