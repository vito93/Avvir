CREATE TABLE [dbo].[GroupRole] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupRole_GUID] DEFAULT (newsequentialid()),
  [Name] [nvarchar](50) NOT NULL,
  [Code] [nvarchar](10) NOT NULL,
  CONSTRAINT [PK_GroupRole] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO