CREATE TABLE [dbo].[UserGroupRole] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_UserGroupRole_GUID] DEFAULT (newsequentialid()),
  [AccountGUID] [uniqueidentifier] NOT NULL,
  [GroupGUID] [uniqueidentifier] NOT NULL,
  [GroupRoleGUID] [uniqueidentifier] NOT NULL,
  CONSTRAINT [PK_UserGroupRole] PRIMARY KEY CLUSTERED ([GUID])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserGroupRole]
  ADD CONSTRAINT [FK_UserGroupRole_Account] FOREIGN KEY ([AccountGUID]) REFERENCES [dbo].[Account] ([GUID])
GO

ALTER TABLE [dbo].[UserGroupRole]
  ADD CONSTRAINT [FK_UserGroupRole_GroupDict] FOREIGN KEY ([GroupGUID]) REFERENCES [dbo].[GroupDict] ([GUID])
GO