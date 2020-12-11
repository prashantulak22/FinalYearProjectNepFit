CREATE TABLE [dbo].[ProgressTracker]
(
	NewHeight decimal(3,2) NOT NULL,
	NewBodyMass decimal(5,2) NOT NULL,
	NewChestSize decimal(4,2) NOT NULL,
	NewArmSize decimal(4,2) NOT NULL,
	NewForearmSize decimal(4,2) NOT NULL,
	NewWristSize decimal(4,2) NOT NULL,
	NewNeckSize decimal(4,2) NOT NULL,
	NewUpperAbs decimal(4,2) NOT NULL,
	NewLowerAbs decimal(4,2) NOT NULL,
	NewHipSize decimal(4,2) NOT NULL,
	NewWaistSize decimal(4,2) NOT NULL,
	NewThighSize decimal(4,2) NOT NULL,
	NewCalveSize decimal(4,2) NOT NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_UserIdProgressTracker]FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])
)
