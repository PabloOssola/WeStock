using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStock.Entities
{
    public class Novedad
    {
	    public int IdNovedad { get; set; }
        public string Descripcion { get; set; }
        public int IdAccion { get; set; }
        public DateTime FechaNovedad { get; set; }
    }
}
