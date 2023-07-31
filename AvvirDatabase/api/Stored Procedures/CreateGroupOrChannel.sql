create proc api.CreateGroupOrChannel
@CreatorGUID UNIQUEIDENTIFIER = null,
@NewName nvarchar(255) = null,
@GroupTypeGUID UNIQUEIDENTIFIER
as begin
SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
		BEGIN TRANSACTION

		IF (@CreatorGUID IS NULL
			OR @NewName IS NULL
			OR @GroupTypeGUID IS NULL)
		THROW 500010, 'Empty parameters specified', 1

		if(len(@NewName) < 5)
			THROW 500011, 'Too short group name', 1

		insert into dbo.GroupDict(GroupName, GroupTypeGUID, GroupOwnerGUID)
		select @NewName, @GroupTypeGUID, @CreatorGUID

		END TRY
		BEGIN CATCH
		DECLARE @error INT
			  , @message VARCHAR(4000)
		SELECT @error = ERROR_NUMBER()
			 , @message = ERROR_MESSAGE()
		ROLLBACK;
		RAISERROR ('%s: %d: %s', 16, 1, @checkpoint, @error, @message);
		END CATCH

END