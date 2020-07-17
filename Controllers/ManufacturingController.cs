using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;
using System.Threading.Tasks;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturingController : ControllerBase
    {
        private readonly IManufacturingService _manufacturingService;
        public ManufacturingController(IManufacturingService manufacturingService)
        {
            _manufacturingService = manufacturingService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Manufacturing>> GetManufacturings()
        {
            return await _manufacturingService.GetManufacturings();
        }

        [HttpGet("GetManufacturingByVector/{vector}")]
        public async Task<IEnumerable<Manufacturing>> GetManufacturingByVector(string vector)
        {
            return await _manufacturingService.GetManufacturingByVector(vector);
        }

        [HttpGet("GetManufacturingByVectors/{vectors}")]
        public async Task<IEnumerable<Manufacturing>> GetManufacturingByVectors(string vectors)
        {
            return await _manufacturingService.GetManufacturingByVectors(vectors);
        }
    }
}