using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Entities
{
    public class Semana
    {
	    public int IdSemana { get; set; }
        public string Descripcion { get; set; } 
        public DateTime FechaCierre { get; set; } 
    }
}
