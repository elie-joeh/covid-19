using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController: ControllerBase
    {
        private readonly IDebtService _service;
        public DebtController(IDebtService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Debt>> GetDebts()
        {
            return await _service.GetDebts();
        }

        [HttpGet("GetDebtsByVector/{vector_id}")]
        public async Task<IEnumerable<Debt>> GetDebtsByVector(string vector_id)
        {
            return await _service.GetDebtsByVector(vector_id);
        }

        [HttpGet("GetDebtsByVectors/{vector_ids}")]
        public async Task<IEnumerable<Debt>> GetDebtsByVectors(string vector_ids)
        {
            return await _service.GetDebtsByVectors(vector_ids);
        }
    }
}