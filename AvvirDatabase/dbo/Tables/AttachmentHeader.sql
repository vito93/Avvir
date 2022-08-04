CREATE TABLE [dbo].[AttachmentHeader] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_AttachmentHeader_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [Filename]    NVARCHAR (200)   NOT NULL,
    [MimeType]    NVARCHAR (50)    NULL,
    [Created]     DATETIME2 (3)    NULL,
    [MessageGUID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AttachmentHeader] PRIMARY KEY CLUSTERED ([GUID] ASC)
);

