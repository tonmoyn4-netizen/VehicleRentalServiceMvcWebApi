using Newtonsoft.Json; using Newtonsoft.Json.Serialization; using System.Web.Http;
namespace VehicleRentalService { public static class WebApiConfig {
 public static void Register(HttpConfiguration config){config.MapHttpAttributeRoutes();config.Routes.MapHttpRoute("DefaultApi","api/{controller}/{id}",new{id=RouteParameter.Optional});config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore;config.Formatters.JsonFormatter.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();config.EnableCors();}
}}
