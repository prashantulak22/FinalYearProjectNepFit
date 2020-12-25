CREATE TABLE [dbo].[ExerciseRoutine]
(
	[ExerciseRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	Name VARCHAR(5000) NOT NULL,
	Description VARCHAR(5000) NOT NULL,
	Repetition INT NOT NULL,
	Secquence INT NOT NULL,
	Duration INT NOT NULL,
	[ExerciseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT[FK_ExerciseIDRoutine] FOREIGN KEY ([ExerciseId]) REFERENCES[Exercise]([ExerciseId]),
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT[FK_ExercisePackageIDRoutine] FOREIGN KEY ([ExercisePackageId]) REFERENCES[ExercisePackage]([ExercisePackageId]),

	
)