CREATE TABLE [dbo].[NutritionPackageRoutine]
(
	[NutritionPackageRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),  
	[NutritionPackageId] UNIQUEIDENTIFIER NOT NULL , 
	[NutritionRoutineId] UNIQUEIDENTIFIER NOT NULL, 
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
	CONSTRAINT [FK_NutritionPackageRoutine_NutritionPackageId] FOREIGN KEY ([NutritionPackageId]) REFERENCES[NutritionPackage](NutritionPackageId),
    CONSTRAINT [FK_NutritionPackageRoutine_NutritionRoutineId] FOREIGN KEY ([NutritionRoutineId]) REFERENCES[NutritionRoutine](NutritionRoutineId),


)
