CREATE PROCEDURE [dbo].[CrearUsuario]
	@nombre nvarchar(30),
	@nombreUsuario nvarchar(30),
	@password nvarchar(30),
	@email nvarchar(30),
	@idUsuario INT OUTPUT  
AS
DECLARE @resultado TABLE (IdUsuario int)

	INSERT INTO [dbo].[Usuarios]
           (Nombre
           ,NombreUsuario
           ,Password
           ,Email)
	OUTPUT Inserted.IdUsuario INTO @resultado
	VALUES
           (@nombre
           ,@nombreUsuario
           ,@password
           ,@email)

	SELECT @idUsuario = IdUsuario from @resultado 
