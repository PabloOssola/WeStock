using System.Collections.Generic;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Principal");
        }

        public ActionResult Logueado()
        {
            return View("Principal");
        }
    }
}
