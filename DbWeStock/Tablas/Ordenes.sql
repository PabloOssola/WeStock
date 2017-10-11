CREATE TABLE [dbo].[Ordenes]
(
	[IdOrden] INT NOT NULL PRIMARY KEY,
	[TipoOrden] SMALLINT NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[IdProducto] INT NOT NULL,
	[Demanda] INT NULL,
	[Cubierto] INT NULL,
	[Saldo] INT NULL,
	[Precio] DECIMAL(18,2) NULL,
	[Total] DECIMAl(18,2),
	CONSTRAINT [FK_Orden_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
)
