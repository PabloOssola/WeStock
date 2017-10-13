using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeStock.Entities;
using WeStock.Negocio;
using WeStock.Negocio.InterfazHelper;

namespace MisFinanzas.Controllers
{
    public class HomeController : Controller
    {
        private INovedadesHelper helper = new NovedadesHelper();
        public ActionResult Index()
        {
            return View("Principal");
        }

        public ActionResult Logueado(Usuario u)
        {
            List<Novedad> novedades = new List<Novedad>();
            novedades = helper.ObtenerNovedadesDiarias();

            return View("Principal", novedades);
        }

        public ActionResult ImportarArchivos(string cliente, string proveedores, string detalle, string producto)
        {
            List<OrdenCompraSerializados> list = JsonConvert.DeserializeObject<List<OrdenCompraSerializados>>(cliente);
            List<Orden> OrdenesClientes = new List<Orden>();

			foreach (OrdenCompraSerializados orden in list)
			{
                Orden occ = new Orden();
                occ.Descripcion = orden.Descripcion;
				occ.Fecha = orden.Fecha;
                occ.TipoOrden = (TipoOrden)'c';
                occ.Demanda = orden.Demanda;
                occ.Saldo = orden.Saldo;   
                occ.Cubierto = orden.Cubierto;
                occ.Precio = orden.Precio;
                occ.Total = orden.Total;
                OrdenesClientes.Add(occ);
			}


			List<OrdenCompraSerializados> proovedores = JsonConvert.DeserializeObject<List<OrdenCompraSerializados>>(proveedores);
			List<Orden> OrdenesProv = new List<Orden>();

			foreach (OrdenCompraSerializados orden in list)
			{
				Orden ocp = new Orden();
				ocp.Descripcion = orden.Descripcion;
				ocp.Fecha = orden.Fecha;
				ocp.TipoOrden = (TipoOrden)'c';
				ocp.Demanda = orden.Demanda;
				ocp.Saldo = orden.Saldo;
				ocp.Cubierto = orden.Cubierto;
				ocp.Precio = orden.Precio;
				ocp.Total = orden.Total;
				OrdenesProv.Add(ocp);
			}

            //el resultado en un modal que indica que fue satisfactorio
			return PartialView("Gasto", OrdenesClientes);
        }
    }

	internal class OrdenCompraSerializados
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


	internal class DetalleArticuloSerializados
	{
		public String Descripcion { get; set; }
		public Decimal Importe { get; set; }
		public DateTime FechaGasto { get; set; }
	}

	internal class ProductosSerializados
	{
		public String Descripcion { get; set; }
		public Decimal Importe { get; set; }
		public DateTime FechaGasto { get; set; }
	}
}
