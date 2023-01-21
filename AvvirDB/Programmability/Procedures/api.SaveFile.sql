SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
-- =============================================
-- Author:		Victor Klein
-- Create date: 11.08.2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [api].[SaveFile]
	-- Add the parameters for the stored procedure here
	@MessageGUID uniqueidentifier = NULL,
	@MimeType nvarchar(50),
	@Filename nvarchar(200),
	@AttachmentBody varbinary(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @checkpoint nvarchar(32) = isnull(object_name(@@procid), replace(newid(), '-', ''));
    DECLARE @fileCount int
	DECLARE @headerGUID uniqueidentifier

	begin try
        begin transaction

	select @fileCount = count(*)
	from dbo.AttachmentHeader ah
	where ah.MessageGUID = @MessageGUID

	if(@fileCount < 10)
	begin
		create table #temp_GUID ([GUID] uniqueidentifier)

		insert into dbo.AttachmentHeader(MessageGUID
										,[Filename] 
										,MimeType)
		output inserted.GUID into #temp_GUID
		select @MessageGUID,
				@FileName,
				@MimeType


		insert into dbo.AttachmentBody(HeaderGUID, Body)
		select (select top 1 [GUID] from #temp_GUID), @AttachmentBody

	end
	else
		throw 500001, 'Too many files for one message', 1

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