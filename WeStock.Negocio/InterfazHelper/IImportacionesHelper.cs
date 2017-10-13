using System.Collections.Generic; 
using WeStock.Entities;

namespace WeStock.Negocio.InterfazHelper
{
    public interface IImportacionesHelper
    {
        void ImportarClientes(List<Orden> ordenesClientes);
        void ImportarProveedores(List<Orden> ordenesProv);
        void ImportarProductos(List<Producto> productos);
        void ImportarDetalleArticulo(List<Producto> articulos);

    }
}
