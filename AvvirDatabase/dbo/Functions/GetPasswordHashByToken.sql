-- =============================================
-- Author:		Victor Klein
-- Create date: 05.01.2022
-- Description:	Return account's password hash by token
-- =============================================
CREATE FUNCTION GetPasswordHashByToken (@token UNIQUEIDENTIFIER)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @result UNIQUEIDENTIFIER
		   ,@account UNIQUEIDENTIFIER

	SELECT
		@account = AccountGUID
	FROM Token t
	WHERE t.[GUID] = @token

	SELECT
		@result = a.PasswordHash
	FROM Account a
	WHERE a.[GUID] = @account

	RETURN @result

END