﻿/*
Deployment script for AADatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "AADatabase"
:setvar DefaultFilePrefix "AADatabase"
:setvar DefaultDataPath "C:\Users\rachael\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\rachael\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
USE [$(DatabaseName)];


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO

GO
PRINT N'Creating [content]...';


GO
CREATE SCHEMA [content]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [lookups]...';


GO
CREATE SCHEMA [lookups]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [portal]...';


GO
CREATE SCHEMA [portal]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [content].[Categories]...';


GO
CREATE TABLE [content].[Categories] (
    [CategoryId]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (50)  NOT NULL,
    [SortOrder]         INT           NULL,
    [Description]       TEXT          NULL,
    [Active]            BIT           NOT NULL,
    [BannerGraphicFile] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);


GO
PRINT N'Creating [content].[GameCategories]...';


GO
CREATE TABLE [content].[GameCategories] (
    [CategoryId] INT NOT NULL,
    [GameId]     INT NOT NULL,
    [Active]     BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC, [GameId] ASC)
);


GO
PRINT N'Creating [content].[Games]...';


GO
CREATE TABLE [content].[Games] (
    [GameId]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50)  NOT NULL,
    [Link]           VARCHAR (100) NOT NULL,
    [Description]    TEXT          NULL,
    [Graphic400x200] VARCHAR (50)  NULL,
    [Graphic200x100] VARCHAR (50)  NOT NULL,
    [Graphic100x100] VARCHAR (50)  NULL,
    [TechNotes]      TEXT          NULL,
    [Developer]      VARCHAR (50)  NULL,
    [Featured]       BIT           NULL,
    [Priority]       INT           NULL,
    [Title]          VARCHAR (100) NULL,
    [Active]         BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC)
);


GO
PRINT N'Creating [lookups].[AdCycles]...';


GO
CREATE TABLE [lookups].[AdCycles] (
    [AdCycleId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NULL,
    [Active]    BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AdCycleId] ASC)
);


GO
PRINT N'Creating [lookups].[FeatureCycles]...';


GO
CREATE TABLE [lookups].[FeatureCycles] (
    [FeatureCycleId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (100) NULL,
    [Active]         BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([FeatureCycleId] ASC)
);


GO
PRINT N'Creating [portal].[AdvertisementCategories]...';


GO
CREATE TABLE [portal].[AdvertisementCategories] (
    [AdCategoryId]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (50)  NOT NULL,
    [SortOrder]         INT           NOT NULL,
    [Description]       TEXT          NULL,
    [Active]            BIT           NOT NULL,
    [BannerGraphicFile] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([AdCategoryId] ASC)
);


GO
PRINT N'Creating [portal].[Advertisements]...';


GO
CREATE TABLE [portal].[Advertisements] (
    [AdvertisementId]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (50)  NOT NULL,
    [Priority]          INT           NOT NULL,
    [Link]              VARCHAR (100) NOT NULL,
    [ExpirationDate]    DATETIME2 (7) NOT NULL,
    [StartDate]         DATETIME2 (7) NOT NULL,
    [ClientId]          INT           NOT NULL,
    [Title]             VARCHAR (50)  NOT NULL,
    [AdCategoryId]      INT           NOT NULL,
    [BannerGraphicFile] VARCHAR (100) NOT NULL,
    [Active]            BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AdvertisementId] ASC)
);


GO
PRINT N'Creating [portal].[configuration]...';


GO
CREATE TABLE [portal].[configuration] (
    [ConfigId]      INT NOT NULL,
    [AdCycle]       INT NOT NULL,
    [FeatureCycle]  INT NOT NULL,
    [ShowTechNotes] BIT NOT NULL,
    [RequireLogin]  BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([ConfigId] ASC)
);


GO
PRINT N'Creating unnamed constraint on [content].[Categories]...';


GO
ALTER TABLE [content].[Categories]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [content].[GameCategories]...';


GO
ALTER TABLE [content].[GameCategories]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [content].[Games]...';


GO
ALTER TABLE [content].[Games]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [lookups].[AdCycles]...';


GO
ALTER TABLE [lookups].[AdCycles]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [lookups].[FeatureCycles]...';


GO
ALTER TABLE [lookups].[FeatureCycles]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [portal].[AdvertisementCategories]...';


GO
ALTER TABLE [portal].[AdvertisementCategories]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [portal].[Advertisements]...';


GO
ALTER TABLE [portal].[Advertisements]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [portal].[configuration]...';


GO
ALTER TABLE [portal].[configuration]
    ADD DEFAULT 1 FOR [AdCycle];


GO
PRINT N'Creating unnamed constraint on [portal].[configuration]...';


GO
ALTER TABLE [portal].[configuration]
    ADD DEFAULT 1 FOR [FeatureCycle];


GO
PRINT N'Creating unnamed constraint on [portal].[configuration]...';


GO
ALTER TABLE [portal].[configuration]
    ADD DEFAULT 1 FOR [ShowTechNotes];


GO
PRINT N'Creating unnamed constraint on [portal].[configuration]...';


GO
ALTER TABLE [portal].[configuration]
    ADD DEFAULT 1 FOR [RequireLogin];


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'aa18d553-1188-4dd6-999d-28f3226dac56')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('aa18d553-1188-4dd6-999d-28f3226dac56')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a7175e29-3697-4284-8d1e-aabc6743b13f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a7175e29-3697-4284-8d1e-aabc6743b13f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'aec7cb72-1b8c-4990-b5fa-8036d8384530')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('aec7cb72-1b8c-4990-b5fa-8036d8384530')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fd91dd0a-ae7d-42dc-904b-42c2ca673058')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fd91dd0a-ae7d-42dc-904b-42c2ca673058')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ee1b7780-8199-4470-8f8a-64f4cbd626d4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ee1b7780-8199-4470-8f8a-64f4cbd626d4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4e1b6798-0af0-44d3-8a9a-c8f4d1f1c11e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4e1b6798-0af0-44d3-8a9a-c8f4d1f1c11e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '546f9ce2-608a-4340-85b9-08e3784b903f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('546f9ce2-608a-4340-85b9-08e3784b903f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b6a1f5d6-d59b-47d8-832b-2d861ad2f1fc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b6a1f5d6-d59b-47d8-832b-2d861ad2f1fc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3bf47cf7-73aa-4b67-aa1b-cf25e7c1399d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3bf47cf7-73aa-4b67-aa1b-cf25e7c1399d')

GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO