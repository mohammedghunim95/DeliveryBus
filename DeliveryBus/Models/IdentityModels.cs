using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeliveryBus.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNo { get; set; }
        public double Balance { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BusCompany> busCompanies { get; set; }
        public DbSet<BusLine> busLines { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<BusTime> busTimes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDets> BillDets { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<DeliveryBus.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<DeliveryBus.Models.ApplyTrip> ApplyTrips { get; set; }

        public System.Data.Entity.DbSet<DeliveryBus.Models.ContactUs> ContactUs { get; set; }
    }
}