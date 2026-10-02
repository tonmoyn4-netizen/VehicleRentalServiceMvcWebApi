using Microsoft.AspNet.Identity.EntityFramework;
namespace VehicleRentalService.Models {
 public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
  public ApplicationDbContext() : base("DefaultConnection", false) { }
  public static ApplicationDbContext Create(){ return new ApplicationDbContext(); }
 }
}
