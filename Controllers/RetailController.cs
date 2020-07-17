using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailController: ControllerBase
    {
        private readonly IRetailService _service;

        public RetailController(IRetailService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Retail>> GetRetails()
        {
            return await _service.GetRetails();
        }

        [HttpGet("GetRetailsByVector/{vector}")]
        public async Task<IEnumerable<Retail>> GetRetailsByVector(string vector)
        {
            return await _service.GetRetailByVector(vector);
        }

        [HttpGet("GetRetailsByVectors/{vectors}")]
        public async Task<IEnumerable<Retail>> GetRetailsByVectors(string vectors)
        {
            return await _service.GetRetailByVectors(vectors);
        }
    }
}