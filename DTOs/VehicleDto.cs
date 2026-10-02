using System.ComponentModel.DataAnnotations;
namespace VehicleRentalService.DTOs {
 public class VehicleDto {
  public int Id{get;set;} [Required,StringLength(120)] public string Name{get;set;} [Required,StringLength(60)] public string Brand{get;set;}
  [Required,StringLength(60)] public string Model{get;set;} [Range(1900,2100)] public int Year{get;set;}
  [Required,StringLength(30)] public string RegistrationNo{get;set;} [Range(0.01,999999)] public decimal DailyRate{get;set;}
  public bool Available{get;set;} public string Image{get;set;} [Required] public int VehicleCategoryId{get;set;}
  public string VehicleCategoryName{get;set;}
 }
}
