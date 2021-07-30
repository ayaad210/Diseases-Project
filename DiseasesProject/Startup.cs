using DiseasesProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiseasesProject.Startup))]
namespace DiseasesProject
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var rolemanegaer = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolemanegaer.RoleExists("Admins"))
            {
                rolemanegaer.Create(new IdentityRole() { Name = "Admins" });
            }
            if (!rolemanegaer.RoleExists("visitor"))
            {
                rolemanegaer.Create(new IdentityRole() { Name = "visitor" });
            }
        }
    }
}
