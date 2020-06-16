using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]

    public class CitiesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCities() 
        {
          return Ok(CityDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
          try 
          {

            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
              return NotFound();
            }
            return Ok(city);
          } 
          catch (Exception e)
          {
            return BadRequest(e);
          }
        }
    }
}
