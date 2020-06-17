using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using covid19.Data;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ICPIService _service;
        public CPIController(ApplicationDbContext context, ICPIService service)
        {
            _context = context;
            _service = service;
        }

        //Get: api/getCPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPI>>> getCPIs()
        {
            return await _context.CPIs.ToListAsync();
        }


    }
}