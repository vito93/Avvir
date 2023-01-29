CREATE TABLE [dbo].[AccountConfirmationToken] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccountConfirmationToken_GUID] DEFAULT (newsequentialid()),
  [AccountGUID] [uniqueidentifier] NOT NULL,
  [CreateDate] [datetime2] NOT NULL CONSTRAINT [DF_AccountConfirmationToken_CreateDate] DEFAULT (getdate()),
  [IsUsed] [bit] NOT NULL CONSTRAINT [DF_AccountConfirmationToken_IsUsed] DEFAULT (0),
  CONSTRAINT [PK_AccountConfirmationToken] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountConfirmationToken]
  ADD CONSTRAINT [FK_AccountConfirmationToken_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
GO