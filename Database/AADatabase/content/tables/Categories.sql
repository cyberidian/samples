CREATE TABLE [content].[Categories]
(
	[CategoryId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [SortOrder] INT NULL, 
    [Description] TEXT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [BannerGraphicFile] VARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
)
