CREATE TABLE [dbo].[ExercisePackageRoutine]
(
	[ExercisePackageRoutineId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL , 
	[ExerciseRoutineId] UNIQUEIDENTIFIER NOT NULL, 
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
)




