using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Entities
{
    public class Orden
    {
	    public int IdOrden { get; set; }
        public string Descripcion { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public TipoOrden TipoOrden { get; set; }
        public int Demanda { get; set; }
        public int Cubierto { get; set; }
        public int Saldo { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }

    public enum TipoOrden
    {
        OrdenCompraCliente = 1,
        OrdenCompraProveedor = 2
    }
}
