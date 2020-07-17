using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;
using System.Threading.Tasks;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPIController : ControllerBase
    {
        private readonly ICPIService _cpiService;
        public CPIController(ICPIService cpiService)
        {
            _cpiService = cpiService;
        }

        //Get: api/getCPIs
        [HttpGet("[action]")]
        public async Task<IEnumerable<CPI>> GetCPIs()
        {
            return await _cpiService.getCPIs();
        }

        [HttpGet("getCPIByGeo/{geographyName}")]
        public async Task<IEnumerable<CPI>> GetCPIByGeo(string geographyName)
        {
            return await _cpiService.getCPIByGeo(geographyName);
        }

        [HttpGet("getCPIByPpdg/{ppdg}")]
        public async Task<IEnumerable<CPI>> GetCPIByPpdg(string ppdg)
        {
            return await _cpiService.getCPIByPpdg(ppdg);
        }

        [HttpGet("GetCPIByGeosByPPDG/{ppdg}/{geos}")]
        public async Task<IEnumerable<CPI>> GetCPIByGeosByPPDG(string geos, string ppdg)
        {
            return await _cpiService.getCPIByGeosByPPDG(geos, ppdg);
        }

    }
}