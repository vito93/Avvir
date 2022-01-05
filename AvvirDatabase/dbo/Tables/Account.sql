CREATE TABLE [dbo].[Account] (
    [GUID]         UNIQUEIDENTIFIER CONSTRAINT [DF_Account_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [UIN]          NVARCHAR (50)    NOT NULL,
    [Name]         NVARCHAR (100)   NULL,
    [PasswordHash] CHAR (60)        NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [UIN_CHECK] CHECK (NOT [UIN] like '%[^0-9]%'),
    CONSTRAINT [IX_UIN_UNIQUE] UNIQUE NONCLUSTERED ([UIN] ASC)
);



