﻿CREATE TABLE [dbo].[UserExerciseNutrition]
(
	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_UserId]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId]),
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NUll,
    CONSTRAINT [FK_User_Exercise] FOREIGN KEY ([ExercisePackageId]) REFERENCES [ExercisePackage]([ExercisePackageId]), 
	[NutritionTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_User_NutritionType] FOREIGN KEY ([NutritionTypeId]) REFERENCES [NutritionType]([NutritionTypeId]) 
	
)
