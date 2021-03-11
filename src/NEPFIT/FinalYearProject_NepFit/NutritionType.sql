﻿CREATE TABLE [dbo].[NutritionType]
(
	[NutritionTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    Name VARCHAR(5000) NULL,
	Description VARCHAR(5000) NOT NULL,
	Active bit,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DateUpdated DateTime NULL,
	DateCreated DateTime NOT NULL
)