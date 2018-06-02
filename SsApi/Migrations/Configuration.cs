namespace SsApi.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SsApi.Models;
    using SsApi.Models.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SsApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SsApi.Models.ApplicationDbContext context)
        {
            var adminRole = new IdentityRole("Admin");
            context.Roles.AddOrUpdate(r => r.Name, adminRole);

            var trackerRole = new IdentityRole("Tracker");
            context.Roles.AddOrUpdate(r => r.Name, trackerRole);

            context.SaveChanges();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "nathan",
                Email = "nathan@copypastedeveloper.com",
                IsCoach = true
            };

            userManager.CreateAsync(user, "password").Wait();

            var addedUser = context.Users.First(x => x.UserName == user.UserName);

            userManager.AddToRoleAsync(addedUser.Id, "Admin").Wait();


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
        }
    }
}
