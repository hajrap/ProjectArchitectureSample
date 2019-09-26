CREATE TABLE [dbo].[Users] (
    [Id]   INT           NOT NULL,
    [Name] VARCHAR (150) NOT NULL,
    [Email] VARCHAR(250) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

