CREATE TABLE [dbo].[Programs] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.Programs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

