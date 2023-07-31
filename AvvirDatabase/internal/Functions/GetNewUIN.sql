-- =============================================
-- Author:		Victor Klein
-- Create date: 21.01.2023
-- Description:	Returns a UIN for new account
-- =============================================
CREATE FUNCTION internal.GetNewUIN()
RETURNS CHAR(12)
AS
BEGIN

	DECLARE @Uin char(12)

	SELECT @Uin = right(concat(replicate('0', 11), isnull(max(UIN_Bigint), 0) + 1), 12)
	from dbo.Account

	RETURN @Uin

END