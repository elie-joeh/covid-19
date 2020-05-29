using System;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        public ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllCities()
        {
            return Ok(_service.getAllCities());
        }

        [HttpGet("searchCities/{name}")]
        public IActionResult GetCitiesBySearchName(string name)
        {
            return Ok(_service.GetCitiesBySearchName(name));
        }

        

    }
}