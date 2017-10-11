CREATE TABLE [dbo].[ImpProductos]
(
	[Codigo] NVARCHAR(30) NOT NULL,
	[Descripcion] NVARCHAR(50) NOT NULL,
	[Imputable] BIT NOT NULL,
	[Nivel] NVARCHAR(30) NULL,
	[UNI] NVARCHAR(30) NULL,
	[Activado] BIT NULL,
	[Modelo] NVARCHAR(30) NULL,
	[Articulo] NVARCHAR(30) NULL,
	[Notas] NVARCHAR(30) NULL
)
