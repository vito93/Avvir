CREATE TABLE [dbo].[AccountPhoto] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_AccountPhoto_GUID] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [AccountGUID] UNIQUEIDENTIFIER NOT NULL,
    [Filename]    NVARCHAR (255)   NOT NULL,
    [Body]        VARBINARY (MAX)  NOT NULL,
    [OrderNumber] TINYINT          CONSTRAINT [DF_AccountPhoto_OrderNumber] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountPhoto] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_AccountPhoto_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPhoto]
    ON [dbo].[AccountPhoto]([GUID] ASC);

