CREATE TABLE [dbo].[UserExerciseNutrition]
(
	[UserExerciseNutritionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL,

	[UserId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_UserId]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId]),
	[ExerciseNutritionPackageId] UNIQUEIDENTIFIER NOT NUll,
    CONSTRAINT [FK_User_ExerciseNutrition] FOREIGN KEY ([ExerciseNutritionPackageId]) REFERENCES [ExerciseNutritionPackage]([ExerciseNutritionPackageId]), 
	 
	
)
