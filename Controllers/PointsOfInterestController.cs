
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using CityInfo.Api.Models;
using Microsoft.Extensions.Logging;

namespace CityInfo.Api.Controllers
{
  [ApiController]
  [Route("api/cities/{cityId}/pointsofinterest")]
  public class PointsOfInterestController : ControllerBase 
  {
    private readonly ILogger<PointsOfInterestController> _logger;

    public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public IActionResult GetPointsOfInterest(int cityId) 
    {
      try 
      {
        var city = CityDataStore.Current.Cities
          .FirstOrDefault(c => c.Id == cityId);
        
        if (city == null)
        {
          _logger.LogInformation($"City with id: {cityId} not found when accessing points of interest.");
          return NotFound();
        }
        return Ok(city.PointsOfInterest);
      }
      catch (Exception ex)
      {
        _logger.LogCritical($"Error occured while getting points of interest for city with id: {cityId}", ex);
        return StatusCode(500, "A problem occurred while handling this request");
      }

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

      if(poiData.Description == poiData.Name)
      {
        ModelState.AddModelError(
          "Description",
          "The provided description should not match the name."
        );
      }


      // handled by ApiController attribute (magic)
      // if (poiData == null)
      // {
      //   return BadRequest();
      // }
      // handled by ApiController attribute (magic)
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
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

    [HttpPut("{id}")]
    public IActionResult UpdatePointOfInterest(int cityId, int id,
      [FromBody] PointOfInterestForUpdate poiData)
    {
      if(poiData.Description == poiData.Name)
      {
        ModelState.AddModelError(
          "Description",
          "The provided description should not match the name."
        );
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var city = CityDataStore.Current.Cities
        .FirstOrDefault(c => c.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }

      var pointOfInterest = city.PointsOfInterest
        .FirstOrDefault(p => p.Id == id);
      if (pointOfInterest == null)
      {
        return NotFound();
      }

      pointOfInterest.Name = poiData.Name;
      pointOfInterest.Description = poiData.Name;

      return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
      [FromBody] JsonPatchDocument<PointOfInterestForUpdate> patchDoc)
    {
      var city = CityDataStore.Current.Cities
        .FirstOrDefault(city=> city.Id == cityId);
      if (city == null)
      {
        return NotFound();

      }

      var pointOfInterest = city.PointsOfInterest
        .FirstOrDefault(c => c.Id == id);
      if(pointOfInterest == null)
      {
        return NotFound();
      }

      var pointOfInterestToPatch = new PointOfInterestForUpdate()
      {
        Name = pointOfInterest.Name,
        Description = pointOfInterest.Description,
      };

      patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
      {
        ModelState.AddModelError(
          "Description",
          "The provided description should be different from the name."
        );
      }

      var valid = TryValidateModel(pointOfInterestToPatch);
      if (!valid)
      {
        return BadRequest(ModelState);
      }

      
      pointOfInterest.Name = pointOfInterestToPatch.Name;
      pointOfInterest.Description = pointOfInterestToPatch.Description;

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePointOfInterest(int cityId, int id)

    {
      var city = CityDataStore.Current.Cities
        .FirstOrDefault(city=> city.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }

      var pointOfInterest = city.PointsOfInterest
        .FirstOrDefault(c => c.Id == id);
      if(pointOfInterest == null)
      {
        return NotFound();
      }

      city.PointsOfInterest.Remove(pointOfInterest);
      return NoContent();
    }
  }
}