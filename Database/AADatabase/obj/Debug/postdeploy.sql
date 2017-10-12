﻿/*
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

/*portal seed data */
DELETE FROM [portal].[configuration]
GO
INSERT INTO [portal].[configuration]([ConfigId],[AdCycle],[FeatureCycle],[ShowTechNotes],[RequireLogin]) VALUES(1,1,2,1,1)
GO
DELETE FROM [portal].[AdCategories]
GO
SET IDENTITY_INSERT [portal].[AdCategories] ON 
INSERT [portal].[AdCategories] ([AdCategoryId], [Name], [SortOrder], [Description], [BannerGraphicFile], [Active]) VALUES (1, N'Promotions', 1, NULL, N'graphic.png', 1)
INSERT [portal].[AdCategories] ([AdCategoryId], [Name], [SortOrder], [Description], [BannerGraphicFile], [Active]) VALUES (2, N'Art', 2, NULL, N'graphic.png', 1)
SET IDENTITY_INSERT [portal].[AdCategories] OFF
GO

DELETE FROM [portal].[Ads]
GO
SET IDENTITY_INSERT [portal].[Ads] ON 
INSERT [portal].[Ads] ([AdId], [Name], [Priority], [Link], [StartDate], [ExpirationDate], [ClientId], [AdCategoryId], [BannerGraphicFile], [Active]) VALUES (1, N'Retro Rocket', 1, N'http://localhost/pennyarcade/', CAST(0x0700000000005A3D0B AS DateTime2), CAST(0x070000000000C73E0B AS DateTime2), 1, 2, N'ads/adbanner.png', 1)
INSERT [portal].[Ads] ([AdId], [Name], [Priority], [Link], [StartDate], [ExpirationDate], [ClientId], [AdCategoryId], [BannerGraphicFile], [Active]) VALUES (2, N'Space Invaders', 1, N'http://localhost/pennyarcade/', CAST(0x0700000000005A3D0B AS DateTime2), CAST(0x070000000000C73E0B AS DateTime2), 1, 2, N'graphic.png', 1)
SET IDENTITY_INSERT [portal].[Ads] OFF
GO

DELETE FROM [portal].[AdClients]
GO
SET IDENTITY_INSERT [portal].[AdClients] ON 
INSERT [portal].[AdClients] ([AdClientId], [Name], [Active]) VALUES (1, N'Cyberidian', 1)
SET IDENTITY_INSERT [portal].[AdClients] OFF
GO

/* lookup data */
DELETE FROM [lookups].[AdCycles]
GO
SET IDENTITY_INSERT [lookups].[AdCycles] ON 
INSERT [lookups].[AdCycles] ([AdCycleId], [Name], [Active]) VALUES (1, N'Random', 1)
INSERT [lookups].[AdCycles] ([AdCycleId], [Name], [Active]) VALUES (2, N'Priority', 1)
SET IDENTITY_INSERT [lookups].[AdCycles] OFF
GO

DELETE FROM [lookups].[FeatureCycles]
GO
SET IDENTITY_INSERT [lookups].[FeatureCycles] ON 
INSERT [lookups].[FeatureCycles] ([FeatureCycleId], [Name], [Active]) VALUES (1, N'Random', 1)
INSERT [lookups].[FeatureCycles] ([FeatureCycleId], [Name], [Active]) VALUES (2, N'Priority', 1)
SET IDENTITY_INSERT [lookups].[FeatureCycles] OFF

/* content data */
DELETE FROM [content].[Categories] 
GO
DELETE FROM [content].[GameCategories] 
GO
DELETE FROM [content].[Games]
GO

SET IDENTITY_INSERT [content].[Categories] ON 
INSERT [content].[Categories] ([CategoryId], [Name], [SortOrder], [Description], [Active], [BannerGraphicFile]) VALUES (1, N'Card Games', 1, NULL, 1, N'cardgames.png')
INSERT [content].[Categories] ([CategoryId], [Name], [SortOrder], [Description], [Active], [BannerGraphicFile]) VALUES (2, N'Puzzles', 2, NULL, 1, N'halloween-puzzles.png')
INSERT [content].[Categories] ([CategoryId], [Name], [SortOrder], [Description], [Active], [BannerGraphicFile]) VALUES (3, N'Casino', 3, NULL, 1, N'casino.png')
SET IDENTITY_INSERT [content].[Categories] OFF
GO

SET IDENTITY_INSERT [content].[Games] ON 
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (1, N'Go Fish', N'http://localhost/pennyarcade/', 'Play Go Fish against the computer.', N'go-fish.png', N'go-fish-200x100.png', N'go-fish-50x50.png', 'tech notes Go Fish ' , 'Rachael Harralson-Valletta', 1, 1, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (2, N'Go Fish - Multiplayer', N'http://localhost/pennyarcade/', 'Play Go Fish against friends online.', N'go-fish.png', N'go-fish-200x100.png', N'go-fish-50x50.png',  'tech notes Go Fish Multi' , 'Rachael Harralson-Valletta', 0, 2,  1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (3, N'Crazy 8', N'http://localhost/pennyarcade/', 'crazy crazy 8888', N'crazy8.png', N'crazy8-200x100.png', N'crazy8-50x50.png',  'tech notes Crazy 8' , 'Rachael Harralson-Valletta', 1, 3, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (4, N'Halloween Slider 1', N'http://localhost/pennyarcade/','How fast can you solve this spooky slider puzzle?',  N'halloween-puzzles.png', N'halloween-puzzles-200x100.png' , N'halloween-puzzles-50x50.png',  'tech notes Halloween Slider 1' , 'Rachael Harralson-Valletta', 0,4, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (5, N'Halloween Slider 2', N'http://localhost/pennyarcade/', 'How fast can you solve this spooky slider puzzle?', N'halloween-puzzles.png', N'halloween-puzzles-200x100.png', N'halloween-puzzles-50x50.png',  'tech notes Halloween Slider 2' , 'Rachael Harralson-Valletta', 0, 5, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (6, N'Halloween Jigsaw Puzzle', N'http://localhost/pennyarcade/','How fast can you solve this spooky jigsaw puzzle?',  N'halloween-puzzles.png',  N'halloween-puzzle-200x100.png', N'halloween-puzzle-50x50.png',  'tech notes Halloween Jigsaw Puzzle' , 'Rachael Harralson-Valletta', 0, 6, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (7, N'Cat Jigsaw Puzzle', N'http://localhost/pennyarcade/', 'How fast can you solve this cat jigsaw puzzle?', N'cat-puzzle.png', N'cat-puzzle-200x100.png', N'cat-puzzle-50x50.png',  'tech notes Cat Jigsaw Puzzle' , 'Rachael Harralson-Valletta', 0, 7, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (8, N'Black Jack', N'http://localhost/pennyarcade/', 'Try your hand at Black Jack', N'blackjack.png', N'blackjack-200x100.png', N'blackjack-50x50.png', 'tech notes Black Jack', 'Rachael Harralson-Valletta', 1, 8, 1)
INSERT [content].[Games] ([GameId], [Name], [Link], [Description], [Graphic400x200], [Graphic200x100], [Graphic100x100], [TechNotes], [Developer], [Featured], [Priority], [Active]) VALUES (9, N'Roulette', N'http://localhost/pennyarcade/','Are you lucky today?',  N'roulette.png', N'roulette-200x100.png', N'roulette-50x50.png', 'tech notes Roulette', 'Rachael Harralson-Valletta', 0, 9, 1)
SET IDENTITY_INSERT [content].[Games] OFF
GO

INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (1,1,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (1,2,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (1,3,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (2,4,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (2,5,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (2,6,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (2,7,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (3,8,1)
INSERT INTO [content].[GameCategories] ([CategoryId],[GameId],[Active]) VALUES (3,9,1)
GO
