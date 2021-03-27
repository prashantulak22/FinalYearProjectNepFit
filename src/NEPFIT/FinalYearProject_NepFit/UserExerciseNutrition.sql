CREATE TABLE [dbo].[UserExerciseNutrition]
(
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL,

	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_UserId]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId]),
	[ExerciseNutritionPackageId] UNIQUEIDENTIFIER NOT NUll,
    CONSTRAINT [FK_User_ExerciseNutrition] FOREIGN KEY ([ExerciseNutritionPackageId]) REFERENCES [ExerciseNutritionPackage]([ExerciseNutritionPackageId]), 
	 
	
)
