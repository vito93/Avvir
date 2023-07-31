CREATE TABLE [dbo].[AuthorizationToken] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_AuthorizationToken_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AccountGUID] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]  DATETIME2 (7)    CONSTRAINT [DF_AuthorizationToken_CreateDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_AuthorizationToken] PRIMARY KEY CLUSTERED ([GUID] ASC)
);

