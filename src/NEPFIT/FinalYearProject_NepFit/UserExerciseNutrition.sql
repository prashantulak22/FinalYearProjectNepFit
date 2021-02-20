﻿CREATE TABLE [dbo].[UserExerciseNutrition]
(
	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_UserId]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId]),
	[ExerciseId] UNIQUEIDENTIFIER NOT NUll,
    CONSTRAINT [FK_User_Exercise] FOREIGN KEY ([ExerciseId]) REFERENCES [Exercise]([ExerciseId]), 
	[NutritionId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_User_Nutrition] FOREIGN KEY ([NutritionId]) REFERENCES [Nutrition]([NutritionId]) 
	
)
