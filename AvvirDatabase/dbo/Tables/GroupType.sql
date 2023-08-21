CREATE TABLE [dbo].[GroupType] (
    [Id]   TINYINT       IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_GroupType_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

