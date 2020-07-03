
using System.Collections.Generic; 
using CityInfo.Api.Models;

namespace CityInfo.Api
{
  public class CityDataStore
  {
    public List<CityDTO> Cities { get; set; }

    public static CityDataStore Current { get; } = new CityDataStore();

    public CityDataStore()
    {
      Cities = new List<CityDTO>()
      {
        new CityDTO() { 
          Id = 1,
          Name = "New York", 
          Description = "It's basically Jersey",
          PointsOfInterest = new List<PointOfInterestDTO>()
          {
            new PointOfInterestDTO() 
            {
              Id = 1,
              Name = "Central Park",
              Description = "The most visited park in the united states"
            },
            new PointOfInterestDTO() 
            {
              Id = 2,
              Name = "Sears Tower",
              Description = "Was once the tallest building in the world"
            },
          } 
        },
        new CityDTO() { 
          Id = 2, Name = "Boston", Description = "All american place",
          PointsOfInterest = new List<PointOfInterestDTO>()
          {
            new PointOfInterestDTO() 
            {
              Id = 3,
              Name = "Harvard",
              Description = "This probably isn't even in Boston"
            },
            new PointOfInterestDTO() 
            {
              Id = 4,
              Name = "Donut Shop",
              Description = "Some damn good donuts in here"
            },
          }
        },
        new CityDTO() { 
          Id = 3, Name = "Austin", Description = "Texas place",
          PointsOfInterest = new List<PointOfInterestDTO>()
          {
            new PointOfInterestDTO() 
            {
              Id = 5,
              Name = "Lafayette Square",
              Description = "It's more of a round"
            },
            new PointOfInterestDTO() 
            {
              Id = 6,
              Name = "Kennedy Assasination",
              Description = "Dont drive a convertible here if you can avoid it"
            },
          }
        }
      };
    }
  }
}