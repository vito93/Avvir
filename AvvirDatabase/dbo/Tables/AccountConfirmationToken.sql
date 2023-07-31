CREATE TABLE [dbo].[AccountConfirmationToken] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_AccountConfirmationToken_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AccountGUID] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]  DATETIME2 (7)    CONSTRAINT [DF_AccountConfirmationToken_CreateDate] DEFAULT (getdate()) NOT NULL,
    [IsUsed]      BIT              CONSTRAINT [DF_AccountConfirmationToken_IsUsed] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountConfirmationToken] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_AccountConfirmationToken_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
);

