
CREATE TABLE [dbo].[ExerciseRoutine]
(
	[ExerciseRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	Name VARCHAR(5000) NOT NULL,
	Description VARCHAR(5000) NOT NULL,
	Repetition INT NOT NULL,	
	Duration INT NOT NULL,	
	[ExerciseTypeId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_ExerciseRoutine] FOREIGN KEY (ExerciseTypeId) REFERENCES[ExerciseType](ExerciseTypeId)
)