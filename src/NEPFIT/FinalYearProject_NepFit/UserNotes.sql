﻿CREATE TABLE [dbo].[UserNotes]
(
	UserNotesId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
	Notes VARCHAR(5000) NULL,
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL,
	[UserId] UNIQUEIDENTIFIER  NOT NULL,
	CONSTRAINT [FK_Notes] FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])


)
