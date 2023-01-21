CREATE TABLE [dbo].[ContactList] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ContactList_GUID] DEFAULT (newsequentialid()),
  [MainUserGUID] [uniqueidentifier] NOT NULL,
  [SecondaryUserGUID] [uniqueidentifier] NOT NULL,
  [ContactStatus] [tinyint] NOT NULL,
  CONSTRAINT [PK_ContactList] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO