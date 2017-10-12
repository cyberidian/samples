CREATE TABLE [content].[GameCategories]
(
	[CategoryId] INT NOT NULL , 
    [GameId] INT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_GameCategories] PRIMARY KEY ([CategoryId], [GameId]), 
    CONSTRAINT [FK_GameCategories_Games] FOREIGN KEY ([GameId]) REFERENCES [content].[Games]([GameId])
)
