CREATE TABLE [dbo].[Nutrition]
(
	NutritionId UNIQUEIDENTIFIER PRIMARY KEY,
	WeightLossNutrition VARCHAR(MAX) NOT NULL,
	WeightGainNutrition VARCHAR(MAX) NOT NULL,
	FitNutrition VARCHAR(MAX) NOT NULL,
)
