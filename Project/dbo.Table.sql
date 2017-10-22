CREATE TABLE [dbo].[Table]
(
	[AccountId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(50) NULL, 
    [Age] INT NULL
)
