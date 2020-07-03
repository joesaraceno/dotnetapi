using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using CityInfo.Api.Models;

namespace CityInfo.Api.Entities
{
  public class City
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    public ICollection<PointOfInterest> PointsOfInterest { get; set; } 
      = new List<PointOfInterest>();
  }
}