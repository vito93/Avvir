CREATE TABLE [dbo].[AttachmentBody] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AttachmentBody_GUID] DEFAULT (newsequentialid()),
  [HeaderGUID] [uniqueidentifier] NOT NULL,
  [RowGUIDCol] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AttachmentBody_RowGUIDCol] DEFAULT (newsequentialid()) ROWGUIDCOL,
  [Body] [varbinary](max) FILESTREAM NOT NULL,
  CONSTRAINT [PK_AttachmentBody] PRIMARY KEY CLUSTERED ([GUID]),
  CONSTRAINT [rowguidcol_unique] UNIQUE ([RowGUIDCol])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
FILESTREAM_ON UserAttachments
GO

ALTER TABLE [dbo].[AttachmentBody]
  ADD CONSTRAINT [FK_AttachmentBody_AttachmentHeader] FOREIGN KEY ([HeaderGUID]) REFERENCES [dbo].[AttachmentHeader] ([GUID])
GO