CREATE TABLE [lookups].[AdCycles]
(
	[AdCycleId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(100) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_AdCycles] PRIMARY KEY ([AdCycleId])
)
