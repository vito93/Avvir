CREATE TABLE [dbo].[Comment] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Comment_GUID] DEFAULT (newsequentialid()),
  [MessageGUID] [uniqueidentifier] NOT NULL,
  [AuthorGUID] [uniqueidentifier] NOT NULL,
  [Body] [nvarchar](1000) NOT NULL,
  [Created] [datetime] NOT NULL,
  CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comment]
  ADD CONSTRAINT [FK_Comment_Account] FOREIGN KEY ([AuthorGUID]) REFERENCES [dbo].[Account] ([GUID])
GO

ALTER TABLE [dbo].[Comment]
  ADD CONSTRAINT [FK_Comment_Message] FOREIGN KEY ([MessageGUID]) REFERENCES [dbo].[Message] ([GUID])
GO