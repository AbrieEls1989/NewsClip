CREATE TABLE [dbo].[SoldCars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VehicleId] INT NULL, 
    [ClientName] VARCHAR(50) NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [QTY] INT NULL, 
    [ModelId] INT NULL, 
    CONSTRAINT [FK_SoldCars_Vehicles] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles]([Id]), 
    CONSTRAINT [FK_SoldCars_ToTable] FOREIGN KEY ([ModelId]) REFERENCES [ModelDetails]([Id])
)
