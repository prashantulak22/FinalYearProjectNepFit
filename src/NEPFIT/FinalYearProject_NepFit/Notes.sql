﻿CREATE TABLE [dbo].[Notes]
(
	Notes VARCHAR (5000) NULL,
	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_Notes] FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])


)
