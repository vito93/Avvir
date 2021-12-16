CREATE TABLE [dbo].[ContactList] (
    [GUID]              UNIQUEIDENTIFIER CONSTRAINT [DF_ContactList_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [ContactListOwner]  UNIQUEIDENTIFIER NOT NULL,
    [AccountInListGUID] UNIQUEIDENTIFIER NOT NULL,
    [IsApproved]        BIT              CONSTRAINT [DF_ContactList_IsApproved] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ContactList] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_ContactList_Account_InList] FOREIGN KEY ([AccountInListGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_ContactList_Account_Owner] FOREIGN KEY ([ContactListOwner]) REFERENCES [dbo].[Account] ([GUID])
);

