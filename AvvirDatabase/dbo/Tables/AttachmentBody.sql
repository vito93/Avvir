CREATE TABLE [dbo].[AttachmentBody] (
    [GUID]       UNIQUEIDENTIFIER CONSTRAINT [DF_AttachmentBody_GUID] DEFAULT (newsequentialid()) NOT NULL,
    [HeaderGUID] UNIQUEIDENTIFIER NOT NULL,
    [Body]       VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_AttachmentBody] PRIMARY KEY CLUSTERED ([GUID] ASC)
);

