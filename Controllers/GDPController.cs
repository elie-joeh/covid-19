using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GDPController: ControllerBase
    {

        private readonly IGDPService _service;
        public GDPController(IGDPService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GDP>> GetGDPs()
        {
            return await _service.GetGDPs();
        }
        
        public async Task<IEnumerable<GDP>> GetGDPAllIndustry()
        {
            return await _service.GetGDPAllIndustry();
        }

        [HttpGet("GetGDPsByVector/{vector_id}")]
        public async Task<IEnumerable<GDP>> GetGDPsByVector(string vector_id)
        {
            return await _service.GetGDPsByVector(vector_id);
        }

        [HttpGet("GetGDPsByVectors/{vector_ids}")]
        public async Task<IEnumerable<GDP>> GetGDPsByVectors(string vector_ids)
        {
            return await _service.GetGDPsByVectors(vector_ids);
        }

    }
}   