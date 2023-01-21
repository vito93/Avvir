CREATE TABLE [dbo].[Message2Account] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Message2Account_GUID] DEFAULT (newsequentialid()),
  [MessageGUID] [uniqueidentifier] NOT NULL,
  [AccountGUID] [uniqueidentifier] NOT NULL,
  [Viewed] [datetime2] NULL,
  CONSTRAINT [PK_Message2Account] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO