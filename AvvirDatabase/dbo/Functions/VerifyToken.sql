-- =============================================
-- Author:		Victor Klein
-- Create date: 05.01.2022
-- Description:	This function must be used to verify account's token (first version includes only expiration check)
-- =============================================
CREATE FUNCTION VerifyToken (@token UNIQUEIDENTIFIER)
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT
	DECLARE @defaultExpirationTimeoutInHours INT = 8

	SET @Result = 0

	IF (SELECT
				[GUID]
			FROM Token t
			WHERE DATEADD(HOUR, @defaultExpirationTimeoutInHours, t.CreateDate) > GETDATE()
			AND T.[GUID] = @token)
		IS NOT NULL
		
		SET @Result = 1

		RETURN @result

END