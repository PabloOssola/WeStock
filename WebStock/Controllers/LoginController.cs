using System;
using System.Web;
using System.Web.Mvc;
using WeStock.Entities;
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
                //Usuario usuario = helper.ValidarUsuario(nombreUsuario, password);
                Usuario usuario = new Usuario();
                //if (usuario != null)
                //{
                //    HttpSessionStateBase session = HttpContext.Session;
                //    session["usuario"] = usuario;
                    return RedirectToAction("Logueado", "Home", usuario);
                //}
                //else
                //{
                //    return RedirectToAction("Login");
                //}
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public ActionResult Registrarme(string nombreUsuario, string nombre,string email, string password)
        {
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = nombreUsuario;
            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Password = password;

			try
			{
                helper.CrearUsuario(usuario);
                return RedirectToAction("Login");
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