﻿CREATE TABLE [dbo].[NepFitUser]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DateOfBirth] DateTime NOT NULL, 
    [Gender] CHAR(1) NOT NULL, 
    [IsAdmin] bit NOT NULL,
    Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
)
