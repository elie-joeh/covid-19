using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using covid19.Data;
using OfficeOpenXml;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SeedController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> updateData()
        {
            var lstCPIs = _context.CPIs.ToList();
            var lstGeos = _context.Geographies.ToList();

            var result = 0;

            foreach (var geoRecord in lstGeos)
            {
                var geoName = geoRecord.Name;
                var geoCPIs = lstCPIs.FindAll(r => r.GeographyName == geoName);
                geoRecord.CPIs = geoCPIs;
                result += geoCPIs.Count();

                await _context.SaveChangesAsync(); 
            }

            return new JsonResult(new {
                    updated = result
                });

        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult> ImportCPI()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/CPI-test.xlsx")
            );

            using(var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read
            ))
            {
                using(var ep = new ExcelPackage(stream))
                {
                    //get the first worksheet
                    var ws = ep.Workbook.Worksheets[0];

                    //initialize the record counters
                    var nCPI = 0;

                    //create a list containing all the cpis already existing into the database (it will be empty on first run)
                    var lstCPIs = _context.CPIs.ToList();
                    var lstGeos = _context.Geographies.ToList();

                    //iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1 , nRow, ws.Dimension.End.Column];
                        var ref_data = ws.Cells[nRow, 1].GetValue<DateTime>();
                        var vec_id = ws.Cells[nRow, 9].GetValue<string>();
                        var geo_name = getGeoCodeName(ws.Cells[nRow, 2].GetValue<string>().ToLower());

                        if(geo_name != "" && lstCPIs.Where(c => c.Vector_Id==vec_id && c.Reference_date == ref_data).Count() == 0)
                        {
                            //create the CPI entity and fill it with the xslx data
                            var cpi = new CPI();
                            cpi.Reference_date = ref_data;
                            cpi.Vector_Id = vec_id;
                            cpi.GeographyName = geo_name;
                            cpi.DGUID = ws.Cells[nRow, 3].GetValue<string>();
                            cpi.Ppdg = ws.Cells[nRow, 4].GetValue<string>();
                            cpi.Coordinate = ws.Cells[nRow, 10].GetValue<decimal>();
                            cpi.Value = ws.Cells[nRow, 11].GetValue<decimal>();
                            
                            var geo = lstGeos.First(g => g.Name == geo_name);
                            cpi.Geography = geo;

                            _context.CPIs.Add(cpi);
                            await _context.SaveChangesAsync();

                            lstCPIs.Add(cpi);

                            nCPI++;
                        }
                    }

                    return new JsonResult(new {
                        Cpis = nCPI
                    });

                }
            }


        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ImportGeo()
        {
            var geo_path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Geography.xlsx")
            );

            using (var stream = new FileStream(
                geo_path,
                FileMode.Open,
                FileAccess.Read
            ))
            {
                using (var ep = new ExcelPackage(stream))
                {
                    //get the first worksheet
                    var ws = ep.Workbook.Worksheets[0];

                    //initialize the record counters
                    var nGeo = 0;

                    #region import all Geos
                    //Create a list containing all the geos already existing into the Database (it will be empty on first run)
                    var lstGeos = _context.Geographies.ToList();

                    //iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var name = row[nRow, 1].GetValue<string>();

                        if(lstGeos.Where(c => c.Name == name).Count() == 0)
                        {
                            //create the Geo entity and fill it with the xlsx data
                            var geo = new Geography();
                            geo.Name = name;
                            geo.Infected = row[nRow, 2].GetValue<int>();
                            geo.Dead = row[nRow, 3].GetValue<int>();

                            //save it to the database
                            _context.Geographies.Add(geo);
                            await _context.SaveChangesAsync();

                            // store the geo to retrieve its ID later on
                            lstGeos.Add(geo);

                            //increment the counter
                            nGeo++;
                        }
                    }

                    #endregion
                    return new JsonResult(new {
                        Geos = nGeo
                    });
                }
            }
        }

        private string getGeoCodeName(string geo_name)
        {
            switch (geo_name)
            {
                case "canada":
                    return "CA";
                case "newfoundland and labrador":
                    return "NL";
                case "prince edward island":
                    return "PE";
                case "nova scotia":
                    return "NS";
                case "new brunswick":
                    return "NB";
                case "quebec":
                    return "QC";
                case "ontario":
                    return "ON";
                case "manitoba":
                    return "MB";
                case "saskatchewan":
                    return "SK";
                case "alberta":
                    return "AB";
                case "british columbia":
                    return "BC";
                case "whitehorse, yukon":
                    return "YT";
                case "yellowknife, northwest territories":
                    return "NT";
                case "iqaluit, nunavut":
                    return "NU";
                default:
                    return "";
            }
        }

    }
}