using System;
using System.ComponentModel.DataAnnotations;
namespace VehicleRentalService.Models {
 public class RentalCreateDto {
  [Required] public int VehicleId{get;set;} [Required] public int CustomerId{get;set;}
  [Required] public DateTime StartDate{get;set;} [Required] public DateTime EndDate{get;set;}
  [StringLength(300)] public string Notes{get;set;}
 }
}
