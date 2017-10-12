CREATE TABLE [portal].[AdCategories]
(
	[AdCategoryId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [SortOrder] INT NOT NULL, 
    [Description] TEXT NULL, 
    [BannerGraphicFile] VARCHAR(100) NOT NULL,
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_AdCategories] PRIMARY KEY ([AdCategoryId]) 
)
