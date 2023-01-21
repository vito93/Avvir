SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
create proc [api].[AssignUserRole]
@AccountGUID UNIQUEIDENTIFIER = null,
@GroupGUID nvarchar(255) = null,
@GroupRoleGUID UNIQUEIDENTIFIER
as begin
SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
		BEGIN TRANSACTION

		IF (@AccountGUID IS NULL
			OR @GroupGUID IS NULL
			OR @GroupRoleGUID IS NULL)
		THROW 500012, 'Empty parameters specified', 1

		if(exists(select 1 from dbo.UserGroupRole ugr
						where 
							ugr.AccountGUID = @AccountGUID
							and ugr.GroupGUID = @GroupGUID
							and ugr.GroupRoleGUID = @GroupRoleGUID
						))
			THROW 500013, 'Role already exists', 1

		insert into dbo.UserGroupRole(AccountGUID, GroupGUID, GroupRoleGUID)
		select @AccountGUID, @GroupGUID, @GroupRoleGUID

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
GO