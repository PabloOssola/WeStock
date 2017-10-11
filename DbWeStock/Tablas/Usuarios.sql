CREATE TABLE [dbo].[Usuarios]
(
	[IdUsuario] INT NOT NULL PRIMARY KEY,
	[NombreUsuario] NVARCHAR(15) NOT NULL,
	[Nombre] NVARCHAR(30) NOT NULL,
	[Apellido] NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(32) NOT NULL
)
