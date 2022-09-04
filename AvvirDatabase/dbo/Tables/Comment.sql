CREATE TABLE [dbo].[Comment] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_Comment_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [MessageGUID] UNIQUEIDENTIFIER NOT NULL,
    [AuthorGUID]  UNIQUEIDENTIFIER NOT NULL,
    [Body]        NVARCHAR (1000)  NOT NULL,
    [Created]     DATETIME         NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_Comment_Account] FOREIGN KEY ([AuthorGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_Comment_Message] FOREIGN KEY ([MessageGUID]) REFERENCES [dbo].[Message] ([GUID])
);

