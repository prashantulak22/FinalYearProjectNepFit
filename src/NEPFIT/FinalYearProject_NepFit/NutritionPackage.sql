CREATE TABLE [dbo].[NutritionPackage]
(
	[NutritionPackageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(5000) NOT NULL, 
    [Description] VARCHAR(5000) NOT NULL
)
