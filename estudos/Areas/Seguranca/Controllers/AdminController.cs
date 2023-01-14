using Microsoft.AspNet.Identity.Owin;
using estudos.Infraestrutura;
using System.Web.Mvc;
using System.Web;

namespace estudos.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {
        // Definição da Propriedade GerenciadorUsuario
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();

            }
        }
        // GET: Seguranca/Admin
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
    }
}