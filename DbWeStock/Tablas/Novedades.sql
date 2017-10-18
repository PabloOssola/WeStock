CREATE TABLE [dbo].[Novedades]
(
	[IdNovedad] INT NOT NULL PRIMARY KEY IDENTITY,
	[Descripcion] NVARCHAR(50) NOT NULL,
	[IdAccion] INT NOT NULL,
	[FechaNovedad] DATETIME NOT NULL,
	CONSTRAINT [FK_Novedades_Accion] FOREIGN KEY ([IdAccion]) REFERENCES [dbo].[Acciones] ([IdAccion])
)
