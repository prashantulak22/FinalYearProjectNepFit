CREATE TABLE [dbo].[BodyMetrics]
(
	Height decimal(3,2) NOT NULL,
	BodyMass decimal(5,2) NOT NULL,
	[NeckSize] decimal(4,2) NOT NULL,
	[ShoulderSize] decimal(4,2) NOT NULL,
	[ChestSize] decimal(4,2) NOT NULL,
	[UpperAbsSize] decimal(4,2) NOT NULL,
	[LowerAbsSize] decimal(4,2) NOT NULL,
	[HipSize] decimal(4,2) NOT NULL,
	[RightBicepSize] decimal(4,2) NOT NULL,
	[LeftBicepSize] decimal(4,2) NOT NULL,
	[ForeArmSize] decimal(4,2) NOT NULL,
	[WaistSize] decimal(4,2) NOT NULL,
	[RightThighSize] decimal(4,2) NOT NULL,
	[LeftThighSize] decimal(4,2) NOT NULL,
	[RightCalveSize] decimal(4,2) NOT NULL,
	[LeftCalveSize] decimal(4,2) NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[UserId] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CONSTRAINT [FK_UserIdBodyMetrics] FOREIGN KEY ([UserId]) REFERENCES [NepFitUser]([UserId])
)
