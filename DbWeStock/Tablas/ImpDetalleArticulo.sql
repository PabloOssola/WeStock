CREATE TABLE [dbo].[ImpDetalleArticulo]
(
	[Codigo] NVARCHAR(30) NOT NULL,
	[Descripcion] NVARCHAR(50) NOT NULL,
	[Medida] INT NULL,
	[Color] INT NULL,
	[Unidad] NVARCHAR(50) NULL,
	[Deposito] INT NULL,
	[Fecha] DATETIME NULL,
	[Comprobante] NVARCHAR(MAX) NULL,
	[Ingreso] INT NOT NULL,
	[Egresos] INT NOT NULL,
	[Saldo] INT NOT NULL
)
