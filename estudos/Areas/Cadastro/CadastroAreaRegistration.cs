using System.Web.Mvc;

namespace estudos.Areas.Cadastro
{
    public class CadastroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cadastro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cadastro_default",
                "Cadastro/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}