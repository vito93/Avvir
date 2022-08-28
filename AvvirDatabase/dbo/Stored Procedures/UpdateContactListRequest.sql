

-- =============================================
-- Author:		Victor Klein
-- Create date: 28.08.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateContactListRequest]
	-- Add the parameters for the stored procedure here
	@RequestGUID uniqueidentifier = NULL,
	@NewStatus tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	/*
	If the provided request does not exist, an error is thrown
	*/

	if not exists(select 1
					from dbo.ContactListRequest
					where [GUID] = @RequestGUID)
		throw 500005, 'There is no such request', 1

	/*
	You can only switch a request to one of the statuses:
	2. Accepted
	3. Declined

	*/

	if @NewStatus not in (2, 3)
		throw 500006, 'A request may be pending only once', 1


	update dbo.ContactListRequest
	set RequestStatus = @NewStatus
	where [GUID] = @RequestGUID

	if(@NewStatus = 2)
	begin

		declare @senderGUID UNIQUEIDENTIFIER,
				@receiverGUID UNIQUEIDENTIFIER

		select @senderGUID = SenderGUID,
			@receiverGUID = ReceiverGUID
	from dbo.ContactListRequest
	where [GUID] = @RequestGUID

	insert into dbo.ContactList(MainUserGUID,
								SecondaryUserGUID,
								ContactStatus)
	select @senderGUID,
			@receiverGUID,
			1

	insert into dbo.ContactList(MainUserGUID,
								SecondaryUserGUID,
								ContactStatus)
	select @receiverGUID,
			@senderGUID,
			1

	end

	commit

	end try
	begin catch
	    declare @error int, @message varchar(4000)
        select @error = error_number(), @message = error_message()
        rollback; 
        raiserror ('%s: %d: %s', 16, 1, @checkpoint, @error, @message) ;
	end catch
END