using System.ComponentModel.DataAnnotations;
namespace VehicleRentalService.DTOs {
 public class CustomerDto {
  public int Id{get;set;} [Required,StringLength(100)] public string Name{get;set;} [Required,StringLength(30)] public string Phone{get;set;}
  [EmailAddress,StringLength(150)] public string Email{get;set;} [StringLength(250)] public string Address{get;set;} public bool Active{get;set;}
 }
}
