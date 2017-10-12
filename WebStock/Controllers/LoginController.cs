using System;
using System.Web.Mvc;
using WeStock.Negocio;
using WeStock.Negocio.InterfazHelper;

namespace MisFinanzas.Controllers
{
    public class LoginController : Controller
    {
        private ILoginHelper helper = new LoginHelper();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nombreUsuario, string password, bool? remember)
        {
            try
            {
                Usuario usuario = helper.ValidarUsuario(nombreUsuario, password);
                if()
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