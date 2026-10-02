using Microsoft.AspNet.Identity; using Microsoft.AspNet.Identity.EntityFramework; using Microsoft.Owin; using Microsoft.Owin.Security.OAuth; using Owin; using VehicleRentalService.Models; using System; using System.Threading.Tasks;
[assembly: OwinStartup(typeof(VehicleRentalService.Startup))]
namespace VehicleRentalService {
 public partial class Startup { public void ConfigureAuth(IAppBuilder app){app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions{AllowInsecureHttp=true,TokenEndpointPath=new PathString("/Token"),AccessTokenExpireTimeSpan=TimeSpan.FromDays(14),Provider=new ApplicationOAuthProvider()});} }
 public class ApplicationOAuthProvider:OAuthAuthorizationServerProvider {
  public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c){c.Validated();return Task.FromResult<object>(null);}
  public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c){using(var db=new ApplicationDbContext())using(var m=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db))){var u=await m.FindAsync(c.UserName,c.Password);if(u==null){c.SetError("invalid_grant","The username or password is incorrect.");return;}var i=await m.CreateIdentityAsync(u,DefaultAuthenticationTypes.ApplicationCookie);c.Validated(i);}}
 }
}
