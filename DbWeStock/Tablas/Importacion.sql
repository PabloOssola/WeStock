CREATE TABLE [dbo].[Importacion]
(
	[IdImportacion] INT NOT NULL PRIMARY KEY,
	[Archivo] NVARCHAR(30) NOT NULL,
	[CantidadNuevosRegistro] INT NOT NULL,
	[CantidadModificacionRegistros] INT NOT NULL,
	[CantidadEliminacionRegistros] INT NOT NULL,
	[FechaEjecucion] DATETIME NOT NULL,
	[ImpactarCambios] BIT NOT NULL
) 
