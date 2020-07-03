using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models
{
  public class PointOfInterestForCreationDTO
  {
    [Required(ErrorMessage = "Please provide a name field")]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }
  }
}