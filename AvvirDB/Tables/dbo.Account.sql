CREATE TABLE [dbo].[Account] (
  [GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Account_GUID] DEFAULT (newsequentialid()),
  [UIN] [nvarchar](50) NOT NULL,
  [Name] [nvarchar](100) NULL,
  [PasswordHash] [char](60) NOT NULL,
  [Email] [nvarchar](255) NOT NULL,
  [UIN_Bigint] AS (CONVERT([bigint],[UIN])),
  CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([GUID]),
  CONSTRAINT [IX_UIN_UNIQUE] UNIQUE ([UIN]),
  CONSTRAINT [UIN_CHECK] CHECK (NOT [UIN] like '%[^0-9]%')
)
ON [PRIMARY]
GO