using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController: ControllerBase
    {
        private readonly HttpClient client = new HttpClient();

        private readonly ApplicationDbContext _context;

        public UpdateController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
        find a solution to parse the json in an efficent way
        */
        [HttpGet("GetDebtTillDate/{N}")]
        public async Task<ActionResult> GetDebtTillDate(string N)
        {
            const string url = DataConstants.RESTUrl.POST_DATA_VECTORS_N;
            const string vector_id = DataConstants.VectorId.NET_DEBT;

            string postBody = $"[{{ \"vectorId\": {vector_id}, \"latestN\": {N} }}]";

            var postResult = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
            var streamResult = await postResult.Content.ReadAsStringAsync();
            string result = streamResult.Substring(1, streamResult.Length - 2);

            DebtJson deserialized = JsonConvert.DeserializeObject<DebtJson>(result);
            List<Debt> data = deserialized.AllData.Data;

            var lstDebts = _context.Debts.ToList();
            var updatedValues = 0;
            
            foreach(Debt debt in data)
            {
                try
                {
                    debt.Vector_id = vector_id;
                    if(lstDebts.Where(c => c.Vector_id == debt.Vector_id && c.Reference_date.Equals(debt.Reference_date)).Count() == 0)
                    {
                        _context.Debts.Add(debt);
                        await _context.SaveChangesAsync();
                        updatedValues++;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Error in updating debt table: ", e.Message);
                }
            }
            
            return new JsonResult(new {
                        UpdatedValues = updatedValues
                    });
        }

        [HttpGet("GetGDPTillDate/{N}")]
        public async Task<ActionResult> GetGDPTillDate(string N)
        {
            const string url = DataConstants.RESTUrl.POST_DATA_VECTORS_N;
            const string vector_id = DataConstants.VectorId.GDP_ALL_INDUSTRIES;

            string postBody = $"[{{ \"vectorId\": {vector_id}, \"latestN\": {N} }}]";

            var postResult = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
            var streamResult = await postResult.Content.ReadAsStringAsync();
            string result = streamResult.Substring(1, streamResult.Length - 2);

            GDPJson deserialized = JsonConvert.DeserializeObject<GDPJson>(result);
            List<GDP> data = deserialized.AllData.Data;

            var lstGDPs = _context.GDPs.ToList();
            var updatedValues = 0;

            foreach(GDP gdp in data)
            {
                try
                {
                    gdp.Vector_id = vector_id;
                    if(lstGDPs.Where(c => c.Vector_id == gdp.Vector_id && c.Reference_date.Equals(gdp.Reference_date)).Count() == 0)
                    {
                        gdp.Reference_date = gdp.Reference_date.Date;
                        _context.GDPs.Add(gdp);
                        await _context.SaveChangesAsync();
                        updatedValues++;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("Error in updating gdp table: ", e.Message);
                }
            }

            return new JsonResult(new {
                UpdatedValues = updatedValues
            });
        }

    }

    
}