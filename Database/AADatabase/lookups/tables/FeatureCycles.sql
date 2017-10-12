CREATE TABLE [lookups].[FeatureCycles]
(
	[FeatureCycleId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(100) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_FeatureCycles] PRIMARY KEY ([FeatureCycleId])
)
