CREATE TABLE [dbo].[Stock]
(
	[IdStock] INT NOT NULL PRIMARY KEY,
	[IdProducto] INT NOT NULL,
	[StockMinimo] INT NOT NULL,
	[StockActual] INT NOT NULL,
	[BajaLogica] BIT NOT NULL,
	[IdUsuarioModificacion] INT NULL,
	[FechaModificacion] ROWVERSION  NULL,
	CONSTRAINT [FK_Producto_Stock] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
)
