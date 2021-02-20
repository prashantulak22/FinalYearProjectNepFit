CREATE TABLE [dbo].[BodyMetrics]
(
	Height decimal(3,2) NOT NULL,
	BodyMass decimal(5,2) NOT NULL,
	ChestSize decimal(4,2) NOT NULL,
	ArmSize decimal(4,2) NOT NULL,
	ForearmSize decimal(4,2) NOT NULL,
	WristSize decimal(4,2) NOT NULL,
	NeckSize decimal(4,2) NOT NULL,
	UpperAbs decimal(4,2) NOT NULL,
	LowerAbs decimal(4,2) NOT NULL,
	HipSize decimal(4,2) NOT NULL,
	WaistSize decimal(4,2) NOT NULL,
	ThighSize decimal(4,2) NOT NULL,
	CalveSize decimal(4,2) NOT NULL,
	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_UserIdBodyMetrics] FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])
)
