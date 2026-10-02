using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleRentalService.Models {
 public class VehicleCategory {
  public VehicleCategory(){ Vehicles=new HashSet<Vehicle>(); }
  public int Id{get;set;} [Required,StringLength(60)] public string Name{get;set;}
  [StringLength(250)] public string Description{get;set;} public bool Active{get;set;}=true;
  public virtual ICollection<Vehicle> Vehicles{get;set;}
 }
 public class Vehicle {
  public Vehicle(){ Rentals=new HashSet<Rental>(); }
  public int Id{get;set;} [Required,StringLength(120)] public string Name{get;set;}
  [Required,StringLength(60)] public string Brand{get;set;} [Required,StringLength(60)] public string Model{get;set;}
  [Range(1900,2100)] public int Year{get;set;} [Required,StringLength(30)] public string RegistrationNo{get;set;}
  [Range(0.01,999999)] public decimal DailyRate{get;set;} public bool Available{get;set;}=true; public string Image{get;set;}
  [Required] public int VehicleCategoryId{get;set;} [ForeignKey("VehicleCategoryId")] public virtual VehicleCategory VehicleCategory{get;set;}
  public virtual ICollection<Rental> Rentals{get;set;}
 }
 public class Customer {
  public Customer(){ Rentals=new HashSet<Rental>(); }
  public int Id{get;set;} [Required,StringLength(100)] public string Name{get;set;} [Required,StringLength(30)] public string Phone{get;set;}
  [EmailAddress,StringLength(150)] public string Email{get;set;} [StringLength(250)] public string Address{get;set;} public bool Active{get;set;}=true;
  public virtual ICollection<Rental> Rentals{get;set;}
 }
 public class Rental {
  public Rental(){CreatedAt=DateTime.Now;Status=RentalStatus.Pending;}
  public int Id{get;set;} [Required,StringLength(25)] public string RentalNo{get;set;}
  [Required] public int VehicleId{get;set;} [ForeignKey("VehicleId")] public virtual Vehicle Vehicle{get;set;}
  [Required] public int CustomerId{get;set;} [ForeignKey("CustomerId")] public virtual Customer Customer{get;set;}
  [Required] public DateTime StartDate{get;set;} [Required] public DateTime EndDate{get;set;} public DateTime CreatedAt{get;set;}
  [Range(0.01,99999999)] public decimal TotalAmount{get;set;} [Required] public RentalStatus Status{get;set;}
  [StringLength(300)] public string Notes{get;set;}
 }
 public enum RentalStatus { Pending=1, Confirmed=2, Active=3, Completed=4, Cancelled=5 }
 public class VehicleRentalDbContext : ApplicationDbContext {
  public System.Data.Entity.DbSet<VehicleCategory> VehicleCategories{get;set;}
  public System.Data.Entity.DbSet<Vehicle> Vehicles{get;set;}
  public System.Data.Entity.DbSet<Customer> Customers{get;set;}
  public System.Data.Entity.DbSet<Rental> Rentals{get;set;}
 }
}
