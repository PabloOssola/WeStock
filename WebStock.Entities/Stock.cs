using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStock.Entities
{
    public class Stock
    {
	    public int IdStock { get; set; }
        public int IdProducto { get; set; }
        public int StockMinimo { get; set; }
        public int StockActual { get; set; }
        public bool BajaLogica { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }          
    }
}
