CREATE TABLE [dbo].[AttachmentHeader] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AttachmentHeader_GUID] DEFAULT (newsequentialid()),
  [Filename] [nvarchar](200) NOT NULL,
  [MimeType] [nvarchar](50) NULL,
  [Created] [datetime2](3) NULL,
  [MessageGUID] [uniqueidentifier] NULL,
  CONSTRAINT [PK_AttachmentHeader] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO