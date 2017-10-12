using MisFinanzas.Helpers;
using MisFinanzas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class GastoController : Controller
    {
        // GET: Gasto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            if (Session["PersonaId"] != null)
            {
                int idPersona = (int)Session["PersonaId"];
                GastoHelper helper = new GastoHelper();
                List<Gasto> gastos = helper.getByIdPersona(idPersona);
                return View(gastos);
            }
            else {
                return View("Error", Json(new { success = false, message = "Se perdio Session" }, JsonRequestBehavior.AllowGet));
            }
        }

        public ActionResult NewGasto() {
            return PartialView("Gasto"); 
        }

        public ActionResult Save(int idGrupoGasto, DateTime fechaGasto, decimal monto, int idPersona, string Descripcion)
        {
            GastoHelper helper = new GastoHelper();
            helper.saveGasto(idGrupoGasto, fechaGasto, monto, idPersona, Descripcion);
            List<Gasto> gastos = helper.getByIdPersona(idPersona);
            return View(gastos);
        }

        public ActionResult Importar()
        {
            return PartialView("Importar");
        }

        [HttpPost]
        public ActionResult ImportarExcel(string model)
        {
            List<GastosSerializados> list = JsonConvert.DeserializeObject<List<GastosSerializados>>(model);
            List<Gasto> gastos = new List<Gasto>();

            foreach (GastosSerializados gastoTarjeta in list)
            {
                Gasto nuevoGasto = new Gasto();
                nuevoGasto.Descripcion = gastoTarjeta.Descripcion;
                nuevoGasto.FechaGasto = gastoTarjeta.FechaGasto;
                nuevoGasto.GrupoGasto = null;
                nuevoGasto.IdPersona = (int)Session["PersonaId"];
                nuevoGasto.monto = gastoTarjeta.Importe;
                gastos.Add(nuevoGasto);
            }
            //Se supone que el que importa el excel es el dueño del archivo de gastos de la tarjeta

            return PartialView("Gasto", gastos);
        }
    }

    internal class GastosSerializados
    {
        public String Descripcion { get; set; }
        public Decimal Importe { get; set; }
        public DateTime FechaGasto { get; set; }

    }
}