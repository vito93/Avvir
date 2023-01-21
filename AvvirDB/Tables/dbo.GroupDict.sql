CREATE TABLE [dbo].[GroupDict] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupDict_GUID] DEFAULT (newsequentialid()),
  [GroupName] [nvarchar](255) NULL,
  [GroupTypeGUID] [uniqueidentifier] NOT NULL,
  [GroupOwnerGUID] [uniqueidentifier] NOT NULL,
  CONSTRAINT [PK_GroupDict] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[GroupDict]
  ADD CONSTRAINT [FK_GroupDict_GroupType] FOREIGN KEY ([GroupTypeGUID]) REFERENCES [dbo].[GroupType] ([GUID])
GO