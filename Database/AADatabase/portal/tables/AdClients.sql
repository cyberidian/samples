CREATE TABLE [portal].[AdClients]
(
	[AdClientId] INT NOT NULL  IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [Organization] VARCHAR(100) NULL, 
    [Active] BIT NULL, 
    CONSTRAINT [PK_AdClients] PRIMARY KEY ([AdClientId])
)
