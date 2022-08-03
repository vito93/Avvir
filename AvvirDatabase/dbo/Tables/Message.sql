CREATE TABLE [dbo].[Message] (
    [GUID]         UNIQUEIDENTIFIER CONSTRAINT [DF_Message_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AuthorGUID]   UNIQUEIDENTIFIER NOT NULL,
    [ReceiverGUID] UNIQUEIDENTIFIER NULL,
    [MessageBody]  NVARCHAR (MAX)   NOT NULL,
    [CreateDate]   DATETIME2 (7)    CONSTRAINT [DF_Message_CreateDate] DEFAULT (getdate()) NOT NULL,
    [GroupGUID]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_Author] FOREIGN KEY ([AuthorGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_Receiver] FOREIGN KEY ([ReceiverGUID]) REFERENCES [dbo].[Account] ([GUID])
);



