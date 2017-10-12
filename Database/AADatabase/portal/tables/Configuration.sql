CREATE TABLE [portal].[Configuration]
(
	[ConfigId] INT NOT NULL , 
    [AdCycle] INT NOT NULL DEFAULT 1, 
    [FeatureCycle] INT NOT NULL DEFAULT 1, 
    [ShowTechNotes] BIT NOT NULL DEFAULT 1, 
    [RequireLogin] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Configuration] PRIMARY KEY ([ConfigId])
)
