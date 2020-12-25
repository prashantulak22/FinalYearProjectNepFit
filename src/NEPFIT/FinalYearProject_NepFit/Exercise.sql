﻿CREATE TABLE [dbo].[Exercise]
(
	[ExerciseId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [WeightGainRoutine] VARCHAR(MAX) NOT NULL,
	WeightLossRoutine VARCHAR(MAX) NOT NULL,
	FitRoutine VARCHAR(MAX) NOT NULL,
)
