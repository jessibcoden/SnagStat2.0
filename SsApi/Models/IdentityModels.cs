using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SsApi.Models.DataModels;

namespace SsApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public virtual string FirstName
        {
            get; set;
        }
        public virtual string LastName
        {
            get; set;
        }
        public virtual ICollection<Team> Teams
        {
            get; set;
        }
        public virtual int TeamId
        {
            get; set;
        }
        public virtual bool IsCoach
        {
            get; set;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SnagStatAPI", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Game> Games
        {
            get; set;
        }
        public virtual DbSet<Stat> Stats
        {
            get; set;
        }
        public virtual DbSet<StatType> StatTypes
        {
            get; set;
        }
        public virtual DbSet<Team> Teams
        {
            get; set;
        }
        public virtual DbSet<TeamStatType> TeamStatTypes
        {
            get; set;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}