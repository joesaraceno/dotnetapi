
using System.Collections.Generic; 
using CityInfo.Api.Models;

namespace CityInfo.Api
{
  public class CityDataStore
  {
    public List<City> Cities { get; set; }

    public static CityDataStore Current { get; } = new CityDataStore();

    public CityDataStore()
    {
      Cities = new List<City>()
      {
        new City() { 
          Id = 1,
          Name = "New York", 
          Description = "It's basically Jersey",
          PointsOfInterest = new List<PointOfInterest>()
          {
            new PointOfInterest() 
            {
              Id = 1,
              Name = "Central Park",
              Description = "The most visited park in the united states"
            },
            new PointOfInterest() 
            {
              Id = 2,
              Name = "Sears Tower",
              Description = "Was once the tallest building in the world"
            },
          } 
        },
        new City() { 
          Id = 2, Name = "Boston", Description = "All american place",
          PointsOfInterest = new List<PointOfInterest>()
          {
            new PointOfInterest() 
            {
              Id = 3,
              Name = "Harvard",
              Description = "This probably isn't even in Boston"
            },
            new PointOfInterest() 
            {
              Id = 4,
              Name = "Donut Shop",
              Description = "Some damn good donuts in here"
            },
          }
        },
        new City() { 
          Id = 3, Name = "Austin", Description = "Texas place",
          PointsOfInterest = new List<PointOfInterest>()
          {
            new PointOfInterest() 
            {
              Id = 5,
              Name = "Lafayette Square",
              Description = "It's more of a round"
            },
            new PointOfInterest() 
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