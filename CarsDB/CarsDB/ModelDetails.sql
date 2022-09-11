CREATE TABLE [dbo].[ModelDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VehicleId] INT NULL, 
    [ModelDescription] VARCHAR(150) NULL, 
    [Features] TEXT NULL, 
    CONSTRAINT [FK_ModelDetails_ToTable] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles]([Id]) 
)
