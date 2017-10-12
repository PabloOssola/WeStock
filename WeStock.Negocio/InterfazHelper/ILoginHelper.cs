using System;
using WeStock.Entities;

namespace WeStock.Negocio.InterfazHelper
{
    public interface ILoginHelper
    {
        Usuario ValidarUsuario(string nombreUsuario, string password);
        bool CrearUsuario(Usuario usuario);

    }
}
