using Microsoft.AspNet.Identity; using Microsoft.AspNet.Identity.EntityFramework; using VehicleRentalService.DTOs; using VehicleRentalService.Models; using System.Threading.Tasks; using System.Web.Http;
namespace VehicleRentalService.Controllers {
 [AllowAnonymous,RoutePrefix("api/account")] public class AccountController:ApiController {
  [HttpPost,Route("register")] public async Task<IHttpActionResult> Register(RegisterDto m){if(m==null||!ModelState.IsValid)return BadRequest(ModelState);using(var db=new ApplicationDbContext())using(var manager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db))){var u=new ApplicationUser{UserName=m.Email,Email=m.Email};var r=await manager.CreateAsync(u,m.Password);if(!r.Succeeded)return BadRequest(string.Join("; ",r.Errors));}return Ok(new{message="Registration successful. Use POST /Token to obtain a bearer token."});}
 }
}
