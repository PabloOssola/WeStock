using System;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Listar");
        }

        
    }
}