CREATE TABLE [dbo].[ExercisePackage]
(
	[ExercisePackageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    Name VARCHAR(5000) NOT NULL,
	Description VARCHAR(5000) NOT NULL,
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
)




