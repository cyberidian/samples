CREATE TABLE [portal].[Ads]
(
	[AdId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Priority] INT NOT NULL, 
    [Link] VARCHAR(100) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [ExpirationDate] DATETIME2 NOT NULL, 
    [ClientId] INT NOT NULL, 
    [AdCategoryId] INT NOT NULL, 
    [BannerGraphicFile] VARCHAR(100) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Ads] PRIMARY KEY ([AdId])
)
