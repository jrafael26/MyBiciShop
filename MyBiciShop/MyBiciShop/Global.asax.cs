using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyBiciShop.Models;
using MyBiciShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyBiciShop
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperuser(db);
            AddPermisionsToSuperUser(db);
            db.Dispose();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermisionsToSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("admin@mybicishop.com");

            if (!userManager.IsInRole(user.Id, RoleName.Administrador))
            {
                userManager.AddToRole(user.Id, RoleName.Administrador);
            }

            if (!userManager.IsInRole(user.Id, RoleName.Vendedor))
            {
                userManager.AddToRole(user.Id, RoleName.Vendedor);
            }

            if (!userManager.IsInRole(user.Id, RoleName.Cliente))
            {
                userManager.AddToRole(user.Id, RoleName.Cliente);
            }

        }

        private void CreateSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("admin@mybicishop.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin@mybicishop.com",
                    Email = "admin@mybicishop.com"
                };
                userManager.Create(user, "Admin123.");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(RoleName.Administrador))
            {
                roleManager.Create(new IdentityRole(RoleName.Administrador));
            }

            if (!roleManager.RoleExists(RoleName.Vendedor))
            {
                roleManager.Create(new IdentityRole(RoleName.Vendedor));
            }

            if (!roleManager.RoleExists(RoleName.Cliente))
            {
                roleManager.Create(new IdentityRole(RoleName.Cliente));
            }


        }
    }
}
