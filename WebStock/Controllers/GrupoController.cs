using MisFinanzas.Helpers; 
using System.Collections.Generic; 
using System.Net.Http;
using System.Web.Http;

namespace MisFinanzas.Controllers
{
    public class GrupoController : ApiController
    {
        GrupoHelper helper = new GrupoHelper();
        // GET: api/Grupo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Grupo/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(helper.getById(id));
        }

        // POST: api/Grupo
        public void Post([FromBody]string description)
        {
            helper.addGrupo(description);
        }

        // PUT: api/Grupo/5
        public void Put(int id, [FromBody]string description)
        {
            helper.updateGrupo(id, description);
        }

        // DELETE: api/Grupo/5
        public void Delete(int id)
        {
            helper.removeGrupo(id);
        }
    }
}
