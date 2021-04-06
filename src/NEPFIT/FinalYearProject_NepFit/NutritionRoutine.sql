CREATE TABLE [dbo].[NutritionRoutine]
(
	[NutritionRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] VARCHAR(5000) NOT NULL, 
    [Description] VARCHAR(5000) NOT NULL,
    [HowToPrepare] VARCHAR(5000) NOT NULL,
    [FoodCategory] CHAR(1) NULL,
    Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL,
    [NutritionTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_NutritionType] FOREIGN KEY ([NutritionTypeId]) REFERENCES[NutritionType]([NutritionTypeId]),
   
   
)
