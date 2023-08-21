
CREATE proc [api].[CreateUser]
@Name nvarchar(100) = null,
@PasswordHash char(60) = null,
@Email nvarchar(255) = null
as begin
SET NOCOUNT ON;

	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));

	begin try
		BEGIN TRANSACTION

		IF (@Name IS NULL
			OR @PasswordHash IS NULL
			OR @Email IS NULL)
		THROW 500014, 'Empty parameters specified', 1

		if(exists(select 1 from dbo.Account a
						where 
							a.Email = @Email
						))
			THROW 500015, 'Email already exists', 1

		insert into dbo.Account(UIN, [Name], PasswordHash, Email)
		select internal.GetNewUIN(), @Name, @PasswordHash, @Email

		COMMIT;
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
