using Microsoft.AspNet.Identity.EntityFramework;
using estudos.Areas.Seguranca.Models;
using System.Data.Entity;
namespace estudos.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>//persistencia com o segundo banco de dados
    {
        public IdentityDbContextAplicacao() : base("IdentityDb")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(
            new IdentityDbInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
    }
    public class IdentityDbInit :
    DropCreateDatabaseIfModelChanges
    <IdentityDbContextAplicacao>

    {
    }
}