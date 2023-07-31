CREATE TABLE [dbo].[AccountAuthorization] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_AccountAuthorization_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AccountGUID] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]  DATETIME         CONSTRAINT [DF_AccountAuthorization_CreateDate] DEFAULT (getdate()) NOT NULL,
    [ValidTo]     DATETIME         NOT NULL,
    CONSTRAINT [PK_AccountAuthorization] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_AccountAuthorization_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
);

