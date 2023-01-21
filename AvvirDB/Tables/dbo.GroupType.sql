CREATE TABLE [dbo].[GroupType] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupType_GUID] DEFAULT (newsequentialid()),
  [Name] [nvarchar](50) NOT NULL,
  CONSTRAINT [PK_GroupType] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO