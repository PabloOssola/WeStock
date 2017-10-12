using System;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, bool? remember)
        {
            try
            {
                return RedirectToAction("Logueado", "Home");
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public ActionResult Registrarme(string username, string email, string password)
        {
            try
            {
                return View("Success");
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }

		public ActionResult Salir()
		{
			return View("Login");
		}
    }
}