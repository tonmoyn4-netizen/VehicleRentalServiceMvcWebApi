namespace VehicleRentalService.Migrations {
 using Microsoft.AspNet.Identity; using Microsoft.AspNet.Identity.EntityFramework; using System.Data.Entity.Migrations; using VehicleRentalService.Models;
 internal sealed class Configuration:DbMigrationsConfiguration<VehicleRentalDbContext>{
  public Configuration(){AutomaticMigrationsEnabled=false;}
  protected override void Seed(VehicleRentalDbContext db){
   db.VehicleCategories.AddOrUpdate(x=>x.Name,new VehicleCategory{Name="Car",Description="Passenger cars"},new VehicleCategory{Name="SUV",Description="Sport utility vehicles"},new VehicleCategory{Name="Motorbike",Description="Two-wheel vehicles"});db.SaveChanges();
   var car=db.VehicleCategories.First(x=>x.Name=="Car");var suv=db.VehicleCategories.First(x=>x.Name=="SUV");var bike=db.VehicleCategories.First(x=>x.Name=="Motorbike");
   db.Vehicles.AddOrUpdate(x=>x.RegistrationNo,new Vehicle{Name="Toyota Corolla",Brand="Toyota",Model="Corolla",Year=2023,RegistrationNo="DHAKA-1234",DailyRate=3500,VehicleCategoryId=car.Id},new Vehicle{Name="Toyota RAV4",Brand="Toyota",Model="RAV4",Year=2022,RegistrationNo="DHAKA-5678",DailyRate=5500,VehicleCategoryId=suv.Id},new Vehicle{Name="Yamaha FZ",Brand="Yamaha",Model="FZ",Year=2024,RegistrationNo="DHAKA-BK01",DailyRate=1200,VehicleCategoryId=bike.Id});
   db.Customers.AddOrUpdate(x=>x.Phone,new Customer{Name="Demo Customer",Phone="01700000000",Email="demo@example.com",Address="Dhaka"});db.SaveChanges();
   var manager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));if(manager.FindByName("admin@vehicle.local")==null)manager.Create(new ApplicationUser{UserName="admin@vehicle.local",Email="admin@vehicle.local"},"Admin@12345");
  }
 }
}
