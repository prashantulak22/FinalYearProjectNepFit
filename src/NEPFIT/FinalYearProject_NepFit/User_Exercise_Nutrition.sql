CREATE TABLE [dbo].[User_Exercise_Nutrition]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_UserId]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])
	
)
