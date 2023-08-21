CREATE TABLE [dbo].[ContactListRequest] (
    [GUID]          UNIQUEIDENTIFIER CONSTRAINT [DF_ContactListRequest_GUID] DEFAULT (newid()) NOT NULL,
    [SenderGUID]    UNIQUEIDENTIFIER NOT NULL,
    [ReceiverGUID]  UNIQUEIDENTIFIER NOT NULL,
    [Created]       DATETIME2 (3)    CONSTRAINT [DF_ContactListRequest_Created] DEFAULT (getdate()) NOT NULL,
    [RequestStatus] TINYINT          CONSTRAINT [DF_ContactListRequest_RequestStatus] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ContactListRequest] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_ContactListRequest_ContactRequestStatus] FOREIGN KEY ([RequestStatus]) REFERENCES [dbo].[ContactRequestStatus] ([Id])
);

