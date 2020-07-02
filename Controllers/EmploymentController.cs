using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentService _service;
        public EmploymentController(IEmploymentService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Employment>> GetEmployments()
        {
            return await _service.GetEmployments();
        }


        [HttpGet("GetEmploymentsByGeo/{geoName}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsByGeo(string geoName)
        {
            return await _service.GetEmploymentsByGeo(geoName);
        }

        [HttpGet("GetEmploymentsByLfc/{lfc}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsByLfc(int lfc)
        {
            return await _service.GetEmploymentsByLfc(lfc);
        }

        [HttpGet("GetEmploymentByGroup/{group}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsByGroup(int group)
        {
            return await _service.GetEmploymentByGroup(group);
        }

        [HttpGet("GetEmploymentsBySex/{sex}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsBySex(int sex)
        {
            return await _service.GetEmploymentsBySex(sex);
        }

        [HttpGet("GetEmploymentsByLfcSexGroup/{lfc}/{sex}/{group}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsByLfcSexGroup(int lfc, int sex, int group)
        {
            return await _service.GetEmploymentByLfcSexGroup(lfc, sex, group);
        }

        [HttpGet("GetEmploymentsBySexGroup/{sex}/{group}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsBySexGroup(int sex, int group)
        {
            return await _service.GetEmploymentBySexGroup(sex, group);
        }

        [HttpGet("GetEmploymentsBySexesGroup/{sex}/{group}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsBySexesGroup(int sex, int group)
        {
            return await _service.GetEmploymentBySexesGroup(sex, group);
        }

        [HttpGet("GetEmploymentsByLfcSexGroups/{lfc}/{sex}/{groups}")]
        public async Task<IEnumerable<Employment>> GetEmploymentsByLfcSexGroups(int lfc, int sex, int groups)
        {
            return await _service.GetEmploymentByLfcSexGroups(lfc, sex, groups);
        }
    }
}