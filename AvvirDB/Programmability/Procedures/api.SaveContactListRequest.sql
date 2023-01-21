SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO


-- =============================================
-- Author:		Victor Klein
-- Create date: 28.08.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [api].[SaveContactListRequest]
	-- Add the parameters for the stored procedure here
	@SenderGUID uniqueidentifier = NULL,
	@ReceiverGUID uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
        begin transaction

	/*
	Both the recevicer and and sender account GUIDs must be provided as input parameters.
	If not, an error is thrown
	*/

	if(@ReceiverGUID is null or @SenderGUID is null)
		throw 500003, 'Invalid parameters provided for contact list request', 1

	/*
	The sender can not send a request if there is an active one from him for the receiver.

	Contact list request statuses:

	1. Pending
	2. Accepted
	3. Declined

	*/

	if exists(select 1
				from dbo.ContactListRequest
				where SenderGUID = @SenderGUID
						and ReceiverGUID = @ReceiverGUID
						and RequestStatus = 1)
		throw 500004, 'There is already one pending request from sender to receiver', 1


	insert into dbo.ContactListRequest(SenderGUID
								,ReceiverGUID)
	select @SenderGUID
			,@ReceiverGUID

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