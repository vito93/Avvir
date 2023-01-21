CREATE TABLE [dbo].[ContactListRequest] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ContactListRequest_GUID] DEFAULT (newsequentialid()),
  [SenderGUID] [uniqueidentifier] NOT NULL,
  [ReceiverGUID] [uniqueidentifier] NOT NULL,
  [Created] [datetime2](3) NOT NULL CONSTRAINT [DF_ContactListRequest_Created] DEFAULT (getdate()),
  [RequestStatus] [tinyint] NOT NULL CONSTRAINT [DF_ContactListRequest_RequestStatus] DEFAULT (1),
  CONSTRAINT [PK_ContactListRequest] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO