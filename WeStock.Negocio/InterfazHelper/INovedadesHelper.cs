using System;
using System.Collections.Generic; 
using WeStock.Entities;

namespace WeStock.Negocio.InterfazHelper
{
    public interface INovedadesHelper
    {
        List<Novedad> ObtenerNovedadesDiarias();
        void generarNovedades(DateTime fecha);

    }
}
