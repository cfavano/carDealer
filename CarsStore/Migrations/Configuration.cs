namespace CarsStore.Migrations
{
    using CarsStore.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsStore.Models.ApplicationUsersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

    

        protected override void Seed(ApplicationUsersDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //are there roles already?
            if (roleManager.RoleExists("admin"))
                return;

            //create roles
            roleManager.Create(new IdentityRole() { Name = "Disabled" });
            roleManager.Create(new IdentityRole() { Name = "Sales" });
            roleManager.Create(new IdentityRole() { Name = "Admin" });


            //create default user

            var user = new ApplicationUser()
            {
                UserName = "admin@softwareguild.com",
                FirstName = "System",
                LastName = "Admin",
                Email = "admin@softwareguild.com"
            };
            var user1 = new ApplicationUser()
            {
                UserName = "john@softwareguild.com",
                FirstName = "John",
                LastName = "Smith",
                Email = "john@softwareguild.com"
            };
            var user2 = new ApplicationUser()
            {
                UserName = "aaron@softwareguild.com",
                FirstName = "Aaron",
                LastName = "Jones",
                Email = "aaron@softwareguild.com"
            };
            var user3 = new ApplicationUser()
            {
                UserName = "james@softwareguild.com",
                FirstName = "James",
                LastName = "McKinley",
                Email = "james@softwareguild.com"
            };
            var user4 = new ApplicationUser()
            {
                UserName = "disabledAccount@softwareguild.com",
                FirstName = "Disable",
                LastName = "Account",
                Email = "disabledAccount@softwareguild.com"
            };

            //create user with manager class
            userManager.Create(user, "testing123");
            userManager.Create(user1, "testing123");
            userManager.Create(user2, "testing123");
            userManager.Create(user3, "testing123");
            userManager.Create(user4, "testing123");

            //add user to admin role
            userManager.AddToRole(user.Id, "Admin");
            userManager.AddToRole(user1.Id, "Sales");
            userManager.AddToRole(user2.Id, "Sales");
            userManager.AddToRole(user3.Id, "Sales");
            userManager.AddToRole(user4.Id, "Disabled");
        }
    }
}
