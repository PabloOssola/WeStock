using System;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class StockController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Listar");
        }

        public ActionResult StockFuturo()
        {
            return View("ListarStockFuturo");
        }
    }
}