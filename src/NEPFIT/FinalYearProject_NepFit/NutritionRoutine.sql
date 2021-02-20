CREATE TABLE [dbo].[NutritionRoutine]
(
	[NutritionRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(5000) NOT NULL, 
    [Description ] VARCHAR(5000) NOT NULL, 
    [HowToPrepare] VARCHAR(MAX) NOT NULL,
    [NutritionId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_NutritionRoutine] FOREIGN KEY ([NutritionId]) REFERENCES[Nutrition]([NutritionId]),
    [NutritionPackageId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_NutritionPackageIdRoutine] FOREIGN KEY ([NutritionPackageId]) REFERENCES[NutritionPackage]([NutritionPackageId]),
   
)
