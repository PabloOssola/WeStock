using System;
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
            throw new NotImplementedException();
        }

        public Usuario ValidarUsuario(string nombreUsuario, string password)
        {
            throw new NotImplementedException();
        }
    }
}
