using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models
{
  public class PointOfInterestForUpdate
  {
    [MaxLength(50)][Required]
    public string Name { get; set; }
    [MaxLength(200)][Required]
    public string Description { get; set; }
  }
}