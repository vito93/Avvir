CREATE TABLE [dbo].[ContactList] (
    [GUID]              UNIQUEIDENTIFIER CONSTRAINT [DF_ContactList_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [MainUserGUID]      UNIQUEIDENTIFIER NOT NULL,
    [SecondaryUserGUID] UNIQUEIDENTIFIER NOT NULL,
    [ContactStatus]     TINYINT          NOT NULL,
    CONSTRAINT [PK_ContactList] PRIMARY KEY CLUSTERED ([GUID] ASC)
);

