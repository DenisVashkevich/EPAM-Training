using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SalesAnalysis.Models
{
    public class SecurityDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManger = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { UserName = "admin", Email = "vdenis.biocom@gmail.com" };
            string passord = "Qwe12-3";
            var result = userManger.Create(admin, passord);

            if (result.Succeeded)
            {
                userManger.AddToRole(admin.Id, role1.Name);
                userManger.AddToRole(admin.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}