using System.Collections.Generic;
using System.Web.Mvc;
using WebStock.Entities;
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
    }
}
