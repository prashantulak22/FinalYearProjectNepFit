CREATE TABLE [dbo].[ExerciseNutritionPackage]
(
	[ExerciseNutritionPackageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL,
	[NutritionPackageId] UNIQUEIDENTIFIER NOT NULL,
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
	CONSTRAINT [FK_ExercisePackage] FOREIGN KEY ([ExercisePackageId]) REFERENCES [ExercisePackage]([ExercisePackageId])
	CONSTRAINT [FK_NutriitonPackage] FOREIGN KEY ([NutritionPackageId]) REFERENCES [NutritionPackage]([NutritionPackageId])
)
