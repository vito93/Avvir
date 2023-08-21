CREATE TABLE [dbo].[ContactRequestStatus] (
    [Id]   TINYINT      IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_ContactRequestStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

