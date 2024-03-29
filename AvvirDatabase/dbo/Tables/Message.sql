﻿CREATE TABLE [dbo].[Message] (
    [GUID]              UNIQUEIDENTIFIER CONSTRAINT [DF_Message_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [AuthorGUID]        UNIQUEIDENTIFIER NOT NULL,
    [ReceiverGUID]      UNIQUEIDENTIFIER NULL,
    [MessageBody]       NVARCHAR (MAX)   NOT NULL,
    [GroupGUID]         UNIQUEIDENTIFIER NULL,
    [ReplyMessageGUID]  UNIQUEIDENTIFIER NULL,
    [Created]           DATETIME2 (3)    NULL,
    [Edited]            DATETIME2 (3)    NULL,
    [ResendMessageGUID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([GUID] ASC),
    CONSTRAINT [FK_Author] FOREIGN KEY ([AuthorGUID]) REFERENCES [dbo].[Account] ([GUID]),
    CONSTRAINT [FK_Receiver] FOREIGN KEY ([ReceiverGUID]) REFERENCES [dbo].[Account] ([GUID])
);

