CREATE TABLE [dbo].[NepFitUser]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DateOfBirth] DateTime NOT NULL, 
    [Gender] CHAR(1) NOT NULL, 
    [MobileNumber] BIGINT NOT NULL
)
