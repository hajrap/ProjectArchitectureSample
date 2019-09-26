CREATE TABLE [dbo].[Demo] (
    [Id]   INT          NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Email] VARCHAR(250) NOT NULL, 
    CONSTRAINT [PK_Demo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

