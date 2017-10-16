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
        private IImportacionesHelper helperImportaciones = new ImportacionesHelper();

        public ActionResult Index()
        {
            return View("Principal");
        }

        public ActionResult Logueado(Usuario u)
        {
            List<Novedad> novedades = new List<Novedad>();
            //novedades = helper.ObtenerNovedadesDiarias();

            return View("Principal", novedades);
        }

        public ActionResult ImportarArchivos(string cliente, string proveedores, string detalle, string producto)
        {

            if(cliente != null)
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

                helperImportaciones.ImportarClientes(OrdenesClientes);
            }

            if (proveedores != null)
            {
                List<OrdenCompraSerializados> proovedores = JsonConvert.DeserializeObject<List<OrdenCompraSerializados>>(proveedores);
                List<Orden> OrdenesProv = new List<Orden>();

                foreach (OrdenCompraSerializados orden in proovedores)
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

                helperImportaciones.ImportarProveedores(OrdenesProv);
            }

            if (detalle != null)
            {
                List<DetalleArticuloSerializados> stocks = JsonConvert.DeserializeObject<List<DetalleArticuloSerializados>>(detalle);
                List<DetalleArticulo> StockDetalle = new List<DetalleArticulo>();

                foreach (DetalleArticuloSerializados stock in stocks)
                {
                    DetalleArticulo art = new DetalleArticulo();
                    art.Codigo = stock.Codigo;
                    art.Color = stock.Color;
                    art.Comprobante = stock.Comprobante;
                    art.Deposito = stock.Deposito;
                    art.Egreso = stock.Egresos;
                    art.Fecha = stock.Fecha;
                    art.Ingreso = stock.Ingresos;
                    art.Medida = stock.Medida;
                    art.Saldo = stock.Saldo;
                    StockDetalle.Add(art);
                }

                helperImportaciones.ImportarDetalleArticulo(StockDetalle);
            }

            if (producto != null)
            {
                List<ProductosSerializados> productosSerializados = JsonConvert.DeserializeObject<List<ProductosSerializados>>(producto);
                List<Producto> productos = new List<Producto>();

                foreach (ProductosSerializados prod in productosSerializados)
                {
                    Producto prd = new Producto();
                    prd.Codigo = prod.Codigo;
                    prd.Activado = prod.Activado.Equals("S");
                    prd.Articulo = prod.servicio;
                    prd.Descripcion = prod.Descripcion;
                    prd.Imputable = prod.Imputable.Equals("S");
                    prd.Modelo = prod.Modelo;
                    prd.Nivel = prod.Nivel;
                    prd.Notas = prod.Notas;
                    productos.Add(prd);
                }

                helperImportaciones.ImportarProductos(productos);
            }
			
            //el resultado en un modal que indica que fue satisfactorio
			return PartialView("Principal");
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
		public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public int Medida { get; set; }
        public int Color { get; set; }
        public string Unidad { get; set; }
		public int Deposito { get; set; }
		public DateTime Fecha { get; set; }
        public string Comprobante { get; set; }
        public int? Ingresos { get; set; }
        public int? Egresos { get; set; }
        public int Saldo { get; set; }
	}

	internal class ProductosSerializados
	{
		public String Codigo { get; set; }
		public String Descripcion { get; set; }
        public string Imputable { get; set; }
        public string Nivel { get; set; }
		public string UNI { get; set; }
        public string Activado { get; set; }
        public string Modelo { get; set; }
		public string servicio { get; set; }
        public string Notas { get; set; }
	}
}
