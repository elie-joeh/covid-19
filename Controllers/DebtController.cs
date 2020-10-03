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
        public async Task<IEnumerable<Debt>> GetNetDebts()
        {
            return await _service.GetNetDebt();
        }
    }
}