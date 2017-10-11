CREATE TABLE [dbo].[ImpProveedores]
(
	[Fecha] DATETIME NOT NULL,
	[Punto] INT NULL,
	[Numero] INT NULL,
	[Articulo] NVARCHAR(30) NULL,
	[Descripcion] NVARCHAR(50) NULL,
	[CodArticulo] NVARCHAR(30) NULL,
	[UNI] NVARCHAR(30) NULL,
	[Demanda] INT NOT NULL,
	[Cubierto] INT NULL,
	[Saldo] INT NOT NULL,
	[Precio] DECIMAL(18,2) NOT NULL,
	[Total] DECIMAL(18,2) NOT NULL
)
