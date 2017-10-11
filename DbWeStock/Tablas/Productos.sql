CREATE TABLE [dbo].[Productos]
(
	[IdProducto] INT NOT NULL PRIMARY KEY,
	[Codigo] NVARCHAR(30) NOT NULL,
	[Descripcion] NVARCHAR(MAX) NOT NULL,
	[Imputable] BIT NULL,
	[Nivel] NVARCHAR(30) NULL,
	[Uni] NVARCHAR(30) NULL,
	[Activado] BIT NULL,
	[Modelo] NVARCHAR(30) NULL,
	[Articulo] NVARCHAR(30) NULL,
	[Notas] NVARCHAR(30) NULL,
	[BajaLogica] BIT NOT NULL,
) 
