CREATE TABLE [dbo].[Message] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Message_GUID] DEFAULT (newsequentialid()),
  [AuthorGUID] [uniqueidentifier] NOT NULL,
  [ReceiverGUID] [uniqueidentifier] NULL,
  [MessageBody] [nvarchar](max) NOT NULL,
  [GroupGUID] [uniqueidentifier] NULL,
  [ReplyMessageGUID] [uniqueidentifier] NULL,
  [Created] [datetime2](3) NULL,
  [Edited] [datetime2](3) NULL,
  CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Message]
  ADD CONSTRAINT [FK_Author] FOREIGN KEY ([AuthorGUID]) REFERENCES [dbo].[Account] ([GUID])
GO

ALTER TABLE [dbo].[Message]
  ADD CONSTRAINT [FK_Receiver] FOREIGN KEY ([ReceiverGUID]) REFERENCES [dbo].[Account] ([GUID])
GO