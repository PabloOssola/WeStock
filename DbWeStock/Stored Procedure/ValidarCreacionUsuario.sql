CREATE PROCEDURE [dbo].[ValidarCreacionUsuario]
	@nombreUsuario nvarchar(30), 
	@email nvarchar(30), 
	@existe int OUTPUT
AS
SET @Existe = 0

SELECT @existe = COUNT(1) 
FROM [dbo].[Usuarios] as u
WHERE u.NombreUsuario = @nombreUsuario 
OR u.Email = @email		   
