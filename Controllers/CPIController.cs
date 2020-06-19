using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using covid19.Data;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

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
        public async Task<IEnumerable<CPI>> getCPIs()
        {
            return await _cpiService.getCPIs();
        }

        [HttpGet("getCPIByGeo/{geographyName}")]
        public async Task<IEnumerable<CPI>> getCPIByGeo(string geographyName)
        {
            return await _cpiService.getCPIByGeo(geographyName);
        }

        [HttpGet("getCPIByPpdg/{ppdg}")]
        public async Task<IEnumerable<CPI>> getCPIByPpdg(string ppdg)
        {
            return await _cpiService.getCPIByPpdg(ppdg);
        }


        [HttpGet("getCPIByGeoByPPG/{geographyName}/{ppdg}")]
        public async Task<IEnumerable<CPI>> getCPIByGeoByPPG(string geographyName, string ppdg)
        {
            return await _cpiService.getCPIByGeoByPPG(geographyName, ppdg);
        }


    }
}