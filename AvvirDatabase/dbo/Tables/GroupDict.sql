CREATE TABLE [dbo].[GroupDict] (
    [GUID]           UNIQUEIDENTIFIER CONSTRAINT [DF_GroupDict_GUID] DEFAULT (newid()) NOT NULL,
    [GroupName]      NVARCHAR (255)   NULL,
    [GroupOwnerGUID] UNIQUEIDENTIFIER NOT NULL,
    [GroupTypeId]    TINYINT          NOT NULL,
    CONSTRAINT [PK_GroupDict] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_GroupDict_Account] FOREIGN KEY ([GroupOwnerGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_GroupDict_GroupDict] FOREIGN KEY ([GroupTypeId]) REFERENCES [dbo].[GroupType] ([Id])
);

