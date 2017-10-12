CREATE PROCEDURE [dbo].[ValidarUsuario]
	@nombreUsuario nvarchar(30) = NULL,
	@password nvarchar(30) = NULL
AS
	SELECT u.IdUsuario, u.Nombre, u.NombreUsuario, u.Email 
	FROM dbo.Usuarios as u
	WHERE u.NombreUsuario = @nombreUsuario
	AND u.Password = @password

