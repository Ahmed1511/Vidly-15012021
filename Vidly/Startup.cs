using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Vidly.Models;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }

        // Creating Roles
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Manager"))
            {
                role = new IdentityRole();
                role.Name = RoleName.Manager;
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = RoleName.Admin;
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                role = new IdentityRole();
                role.Name = RoleName.User;
                roleManager.Create(role);
            }

        }
        // Creating Users
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            // Create the Manager
            user.Email = "ali@gmail.com";
            user.UserName = "lilo";
            var check = userManager.Create(user, "Al@-102030");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, RoleName.Manager);
            }
            // Create the Admin
            var User2 = new ApplicationUser();
            User2.Email = "admin@gmail.com";
            User2.UserName = "Admin";
            var check2 = userManager.Create(User2, "admin@102030");
            if (check.Succeeded)
            {
                userManager.AddToRole(User2.Id, RoleName.Admin);
            }
            // Create the User
            var User3 = new ApplicationUser();
            User3.Email = "User@gmail.com";
            User3.UserName = "User";
            var check3 = userManager.Create(User3, "User@102030");
            if (check3.Succeeded)
            {
                userManager.AddToRole(User3.Id, RoleName.User);
            }


        }


    }




}
