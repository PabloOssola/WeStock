using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Entities
{
    public class Producto
    {
	    public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }        
        public bool Imputable { get; set; }
        public string Nivel { get; set; }
        public string Uni { get; set; }
        public bool Activado { get; set; }
        public string Modelo { get; set; }
        public string Articulo { get; set; }
        public string Notas { get; set; }
        public bool BajaLogica { get; set; }
    } 
}
