
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using CityInfo.Api.Models;

namespace CityInfo.Api.Controllers
{
  [ApiController]
  [Route("api/cities/{cityId}/pointsofinterest")]
  public class PointsOfInterestController : ControllerBase 
  {
    [HttpGet]
    public IActionResult GetPointsOfInterest(int cityId) 
    {
      var city = CityDataStore.Current.Cities
        .FirstOrDefault(c => c.Id == cityId);
      
      if (city == null)
      {
        return NotFound();
      }
      return Ok(city.PointsOfInterest);

    }

    [HttpGet("{id}", Name="GetPointOfInterest")]
    public IActionResult GetPointOfInterest(int cityId, int id) 
    {
      var city = CityDataStore.Current.Cities
        .FirstOrDefault(c => c.Id == cityId);
      
      if (city == null)
      {
        return NotFound();
      }

      var poi = city.PointsOfInterest
        .FirstOrDefault(p => p.Id == id);

      if (poi == null)
      {
        return NotFound();
      }
      return Ok(poi);
      
    }
    [HttpPost]
    public IActionResult CreatePointOfInterest(int cityId,
      [FromBody] PointOfInterestForCreation poiData)
    {
      // handled by ApiController attribute (magic)
      // if (poiData == null)
      // {
      //   return BadRequest();
      // }
      var city = CityDataStore.Current.Cities
        .FirstOrDefault(c => c.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }
      var maxPoiId = CityDataStore.Current.Cities
        .SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

      var nextPoi = new PointOfInterest()
      {
        Id = ++maxPoiId,
        Name = poiData.Name,
        Description = poiData.Description
      };

      city.PointsOfInterest.Add(nextPoi);
      return CreatedAtRoute("GetPointOfInterest",
        new { cityId, id = nextPoi.Id }, nextPoi);
    }

  }
}