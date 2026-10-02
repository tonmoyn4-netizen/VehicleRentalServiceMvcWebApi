using System;
using VehicleRentalService.Models;
namespace VehicleRentalService.DTOs {
 public class RentalDto {
  public int Id{get;set;} public string RentalNo{get;set;} public int VehicleId{get;set;} public string VehicleName{get;set;}
  public int CustomerId{get;set;} public string CustomerName{get;set;} public DateTime StartDate{get;set;} public DateTime EndDate{get;set;}
  public DateTime CreatedAt{get;set;} public decimal TotalAmount{get;set;} public RentalStatus Status{get;set;} public string Notes{get;set;}
 }
}
