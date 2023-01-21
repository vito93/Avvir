﻿CREATE TABLE [dbo].[AspNetUserClaims] (
  [Id] [int] IDENTITY,
  [UserId] [nvarchar](450) NOT NULL,
  [ClaimType] [nvarchar](max) NULL,
  [ClaimValue] [nvarchar](max) NULL,
  CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX [IX_AspNetUserClaims_UserId]
  ON [dbo].[AspNetUserClaims] ([UserId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserClaims]
  ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO