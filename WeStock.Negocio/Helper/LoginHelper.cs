using System;
using WeStock.DAL;
using WeStock.Entities;
using WeStock.Negocio.InterfazHelper;

namespace WeStock.Negocio
{
    public class LoginHelper : ILoginHelper
    {
        public LoginHelper() 
        {
        }

        public bool CrearUsuario(Usuario usuario)
        {
            if (UsuariosDAL.ValidarCreacionUsuario(usuario.NombreUsuario, usuario.Email))
            {
                int idUsuario = UsuariosDAL.CrearUsuario(usuario.Nombre, usuario.NombreUsuario, usuario.Password, usuario.Email);
                usuario.IdUsuario = idUsuario;
                return true;
            }
            else
            {
                throw new Exception(string.Format("Error al intentar crear un usuario, el nombre de usuario {0} o el Email {1} ya existe", usuario.NombreUsuario, usuario.Email));
            }            
        }

        public Usuario ValidarUsuario(string nombreUsuario, string password)
        {
            Usuario u = UsuariosDAL.ValidarUsuario(nombreUsuario, password);
            return u;
        }
    }
}
