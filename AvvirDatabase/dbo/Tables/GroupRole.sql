﻿CREATE TABLE [dbo].[GroupRole] (
    [Id]   TINYINT       IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Code] NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_GroupRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

