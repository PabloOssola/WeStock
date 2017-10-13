using System;
using System.Collections.Generic;
using WeStock.Entities;
using WeStock.Negocio.InterfazHelper;

namespace WeStock.Negocio
{
    public class ImportacionesHelper : IImportacionesHelper
    {
        public ImportacionesHelper() 
        {
        }

		public void ImportarClientes(List<Orden> ordenesClientes)
        {
            throw new NotImplementedException();
        }
		public void ImportarProveedores(List<Orden> ordenesProv)
		{
            throw new NotImplementedException();
        }
        public void ImportarProductos(List<Producto> productos)
		{
            throw new NotImplementedException();
        }
        public void ImportarDetalleArticulo(List<Producto> articulos)
        {
            throw new NotImplementedException();
        }
	}
}
