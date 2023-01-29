CREATE TABLE [dbo].[AuthorizationToken] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AuthorizationToken_GUID] DEFAULT (newsequentialid()),
  [AccountGUID] [uniqueidentifier] NOT NULL,
  [CreateDate] [datetime2] NOT NULL CONSTRAINT [DF_AuthorizationToken_CreateDate] DEFAULT (getdate()),
  CONSTRAINT [PK_AuthorizationToken] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO