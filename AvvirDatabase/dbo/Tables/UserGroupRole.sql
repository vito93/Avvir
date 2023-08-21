CREATE TABLE [dbo].[UserGroupRole] (
    [GUID]        UNIQUEIDENTIFIER CONSTRAINT [DF_UserGroupRole_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AccountGUID] UNIQUEIDENTIFIER NOT NULL,
    [GroupGUID]   UNIQUEIDENTIFIER NOT NULL,
    [GroupRoleId] TINYINT          NOT NULL,
    CONSTRAINT [PK_UserGroupRole] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_UserGroupRole_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_UserGroupRole_GroupRole] FOREIGN KEY ([GroupRoleId]) REFERENCES [dbo].[GroupRole] ([Id])
);

