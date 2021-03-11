CREATE TABLE [dbo].[NutritionPackageRoutine]
(
	[NutritionPackageRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[NutritionPackageId] UNIQUEIDENTIFIER NOT NULL , 
	[NutritionRoutineId] UNIQUEIDENTIFIER NOT NULL, 
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
)
