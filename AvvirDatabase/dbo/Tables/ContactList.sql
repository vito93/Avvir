CREATE TABLE [dbo].[ContactList] (
    [MainUserGUID]      UNIQUEIDENTIFIER NOT NULL,
    [SecondaryUserGUID] UNIQUEIDENTIFIER NOT NULL,
    [ContactStatus]     TINYINT          NOT NULL,
    CONSTRAINT [PK_ContactList_1] PRIMARY KEY CLUSTERED ([MainUserGUID] ASC, [SecondaryUserGUID] ASC)
);

