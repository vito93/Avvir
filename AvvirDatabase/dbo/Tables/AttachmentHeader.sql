CREATE TABLE [dbo].[AttachmentHeader] (
    [GUID]               UNIQUEIDENTIFIER CONSTRAINT [DF_AttachmentHeader_GUID] DEFAULT (newid()) NOT NULL,
    [Filename]           NVARCHAR (200)   NOT NULL,
    [MimeType]           NVARCHAR (50)    NULL,
    [Created]            DATETIME2 (3)    NULL,
    [MessageGUID]        UNIQUEIDENTIFIER NULL,
    [AttachmentBodyGUID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AttachmentHeader] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_AttachmentHeader_AttachmentBody] FOREIGN KEY ([AttachmentBodyGUID]) REFERENCES [dbo].[AttachmentBody] ([GUID])
);

