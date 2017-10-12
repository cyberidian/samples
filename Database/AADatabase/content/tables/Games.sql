CREATE TABLE [content].[Games]
(
	[GameId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Link] VARCHAR(100) NOT NULL, 
    [Description] TEXT NULL, 
    [Graphic400x200] VARCHAR(50) NULL, 
    [Graphic200x100] VARCHAR(50) NOT NULL, 
    [Graphic100x100] VARCHAR(50) NULL, 
    [TechNotes] TEXT NULL, 
    [Developer] VARCHAR(50) NULL, 
    [Featured] BIT NULL, 
    [Priority] INT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Games] PRIMARY KEY ([GameId])
)
