
CREATE TABLE [dbo].[ExerciseRoutine]
(
	[ExerciseRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	Name VARCHAR(5000) NOT NULL,
	Description VARCHAR(5000) NOT NULL,
	Repetition VARCHAR(5000) NOT NULL,
	Sequence INT NOT NULL,
	Duration INT NOT NULL,
	[ExerciseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_ExerciseRoutine] FOREIGN KEY ([ExerciseId]) REFERENCES[Exercise]([ExerciseId]),
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_ExercisePackageIdRoutine] FOREIGN KEY ([ExercisePackageId]) REFERENCES[ExercisePackage]([ExercisePackageId]),
	

	
	


)