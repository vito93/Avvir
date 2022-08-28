CREATE TABLE [dbo].[AttachmentBody] (
    [GUID]       UNIQUEIDENTIFIER           CONSTRAINT [DF_AttachmentBody_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [HeaderGUID] UNIQUEIDENTIFIER           NOT NULL,
    [RowGUIDCol] UNIQUEIDENTIFIER           CONSTRAINT [DF_AttachmentBody_RowGUIDCol] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [Body]       VARBINARY (MAX) FILESTREAM NOT NULL,
    CONSTRAINT [PK_AttachmentBody] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_AttachmentBody_AttachmentHeader] FOREIGN KEY ([HeaderGUID]) REFERENCES [dbo].[AttachmentHeader] ([GUID]),
    CONSTRAINT [rowguidcol_unique] UNIQUE NONCLUSTERED ([RowGUIDCol] ASC)
) FILESTREAM_ON [UserAttachments];





