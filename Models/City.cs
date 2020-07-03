using System.Collections.Generic;
namespace CityInfo.Api.Models

{
  public class CityDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberPointsOfInterest  {
      get {
        return PointsOfInterest.Count;
      }
    }
    public ICollection<PointOfInterestDTO> PointsOfInterest { get; set; } 
      = new List<PointOfInterestDTO>();
  }
}