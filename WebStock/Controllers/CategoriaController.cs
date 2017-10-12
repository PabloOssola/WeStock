using MisFinanzas.Helpers;
using MisFinanzas.Models; 
using System.Collections.Generic; 
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {            
            GrupoGastoHelper helper = new GrupoGastoHelper();
            List<GrupoGasto> grupoGastos = helper.getAll();
            return View(grupoGastos);            
        }

        public ActionResult NewCategoria()
        {
            return PartialView("Categoria");
        }

        public ActionResult Save(string idTipoGasto, string Descripcion)
        {
            GrupoGastoHelper helper = new GrupoGastoHelper();
            helper.saveGrupoGasto(int.Parse(idTipoGasto), Descripcion);
            List<GrupoGasto> caterogias = helper.getAll();
            return View("Listar", caterogias);
        }

        public ActionResult Delete(int id)
        {
            GrupoGastoHelper helper = new GrupoGastoHelper();
            helper.removeGrupoGasto(id);
            List<GrupoGasto> caterogias = helper.getAll();
            return View("Listar", caterogias);
        }
    }
}