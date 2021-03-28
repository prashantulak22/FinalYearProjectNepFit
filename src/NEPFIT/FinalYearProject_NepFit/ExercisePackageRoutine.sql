CREATE TABLE [dbo].[ExercisePackageRoutine]
(
	[ExercisePackageRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL , 
	[ExerciseRoutineId] UNIQUEIDENTIFIER NOT NULL, 
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL,
	CONSTRAINT [FK_ExercisePackageRoutine_ExercisePackageId] FOREIGN KEY (ExercisePackageId) REFERENCES[ExercisePackage](ExercisePackageId),
    CONSTRAINT [FK_ExercisePackageRoutine_ExerciseRoutineId] FOREIGN KEY (ExerciseRoutineId) REFERENCES[ExerciseRoutine](ExerciseRoutineId),
)




