CREATE TABLE [dbo].[Rooms] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)  NOT NULL,
    [Category]      NVARCHAR (100)  NOT NULL,
    [Price]         DECIMAL (16, 2) NOT NULL,
    [Description]   NVARCHAR (100)  NOT NULL,
    [ImageFileName] NVARCHAR (100)  NOT NULL,
    [CreatedAt]     DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

