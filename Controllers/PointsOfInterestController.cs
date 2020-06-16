using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CityInfo.Api;

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

    [HttpGet("{id}")]
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

  }
}