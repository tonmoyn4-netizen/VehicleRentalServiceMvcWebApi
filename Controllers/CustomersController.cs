using VehicleRentalService.DTOs; using VehicleRentalService.Models; using System.Linq; using System.Web.Http; using System.Data.Entity;
namespace VehicleRentalService.Controllers {
 [Authorize,RoutePrefix("api/customers")] public class CustomersController:ApiController {
  VehicleRentalDbContext db=new VehicleRentalDbContext();
  [HttpGet,Route("")] public IHttpActionResult GetAll()=>Ok(db.Customers.Select(x=>new CustomerDto{Id=x.Id,Name=x.Name,Phone=x.Phone,Email=x.Email,Address=x.Address,Active=x.Active}).ToList());
  [HttpGet,Route("{id:int}")] public IHttpActionResult Get(int id){var x=db.Customers.Find(id);if(x==null)return NotFound();return Ok(new CustomerDto{Id=x.Id,Name=x.Name,Phone=x.Phone,Email=x.Email,Address=x.Address,Active=x.Active});}
  [HttpPost,Route("")] public IHttpActionResult Post(CustomerDto m){if(m==null||!ModelState.IsValid)return BadRequest(ModelState);var x=new Customer{Name=m.Name,Phone=m.Phone,Email=m.Email,Address=m.Address,Active=m.Active};db.Customers.Add(x);db.SaveChanges();return Created("api/customers/"+x.Id,x);}
  [HttpPut,Route("{id:int}")] public IHttpActionResult Put(int id,CustomerDto m){if(m==null||!ModelState.IsValid)return BadRequest(ModelState);var x=db.Customers.Find(id);if(x==null)return NotFound();x.Name=m.Name;x.Phone=m.Phone;x.Email=m.Email;x.Address=m.Address;x.Active=m.Active;db.SaveChanges();return Ok(x);}
  [HttpDelete,Route("{id:int}")] public IHttpActionResult Delete(int id){var x=db.Customers.Include(c=>c.Rentals).FirstOrDefault(c=>c.Id==id);if(x==null)return NotFound();if(x.Rentals.Any())return BadRequest("Customer has rental history and cannot be deleted.");db.Customers.Remove(x);db.SaveChanges();return Ok(new{message="Customer deleted successfully."});}
 }
}
