CREATE TABLE [dbo].[AccountAuthorization] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountAuthorization_GUID] DEFAULT (newsequentialid()),
  [AccountGUID] [uniqueidentifier] NOT NULL,
  [CreateDate] [datetime] NOT NULL CONSTRAINT [DF_AccountAuthorization_CreateDate] DEFAULT (getdate()),
  [ValidTo] [datetime] NOT NULL,
  CONSTRAINT [PK_AccountAuthorization] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountAuthorization]
  ADD CONSTRAINT [FK_AccountAuthorization_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
GO