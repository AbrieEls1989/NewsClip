CREATE TABLE [dbo].[Vehicles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Make] VARCHAR(50) NULL, 
    [Model] VARCHAR(50) NULL, 
    [QTY] INT NULL, 
    [img] VARCHAR(100) NULL
)
