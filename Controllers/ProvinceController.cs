using System;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    public class ProvinceController : Controller
    {
        public IProvinceService _service;
        public ProvinceController(IProvinceService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllProvinces()
        {
            var allProvinces = _service.getAllProvinces();
            return Ok(allProvinces);
        }

        [HttpGet("SingleProvince{name}")]
        public IActionResult GetProvinceByName(string name)
        {
            var province = _service.getProvinceByName(name);
            return Ok(province);
        }

    }
}