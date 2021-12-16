CREATE TABLE [dbo].[GroupDict] (
    [GUID]          UNIQUEIDENTIFIER CONSTRAINT [DF_GroupDict_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [Code]          NVARCHAR (50)    NOT NULL,
    [GroupTypeGUID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_GroupDict] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_GroupDict_GroupType] FOREIGN KEY ([GroupTypeGUID]) REFERENCES [dbo].[GroupType] ([GUID])
);

