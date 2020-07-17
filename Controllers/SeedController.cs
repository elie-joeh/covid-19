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
            var lstGDPs = _context.GDPs.ToList();
            var lstRetails = _context.Retails.ToList();

            var result = 0;

            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Retail.xlsx")
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

                    for(var i=0; i<lstRetails.Count(); i++)
                    {
                        var retail = lstRetails[i];
                        retail.geography_name = getGeoCodeName(getGeoCodeName(ws.Cells[i+2, 2].GetValue<string>()).ToLower().Trim());
                        await _context.SaveChangesAsync();
                        result++;
                    }
                }
                
            }
            return new JsonResult(new {
                    updated = result
                });

        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ImportManufacturing()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Manufacturing.xlsx")
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
                    var nManufacturing = 0;

                    //create a list containing all the debts already existing into the database
                    var lstManufacturing = _context.Manufacturings.ToList();

                    for(int nRow = 2; nRow<ws.Dimension.End.Row; nRow++)
                    {
                        Manufacturing manu = new Manufacturing();
                        
                        manu.Reference_date = ws.Cells[nRow, 1].GetValue<DateTime>();
                        manu.Vector_id = ws.Cells[nRow, 11].GetValue<string>();
                        manu.Geography_name = getGeoCodeName(ws.Cells[nRow, 2].GetValue<string>().ToLower().Trim());
                        manu.Adjustment = getAdjustments(ws.Cells[nRow, 5].GetValue<string>().ToLower().Trim());
                        manu.Principal_statistics = getPrincipalStat(ws.Cells[nRow, 4].GetValue<string>().ToLower().Trim());
                        manu.Industry_classification = ws.Cells[nRow, 6].GetValue<string>();
                        manu.Value = ws.Cells[nRow, 13].GetValue<decimal>();
                        if(manu.Principal_statistics == -1)
                        {
                            continue;
                        }
                         _context.Manufacturings.Add(manu);
                        await _context.SaveChangesAsync();
                            
                        lstManufacturing.Add(manu);

                        nManufacturing++;
                    }

                    return new JsonResult(new {
                        Manufacturing = nManufacturing
                    });
                }
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ImportRetail()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Retail.xlsx")
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
                    var nRetail = 0;

                    //create a list containing all the debts already existing into the database
                    var lstRetail = _context.Retails.ToList();

                    for(int nRow = 100146; nRow<ws.Dimension.End.Row; nRow++)
                    {
                        Retail retail = new Retail();

                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        
                        retail.reference_date = ws.Cells[nRow, 1].GetValue<DateTime>();
                        retail.vector_id = ws.Cells[nRow, 10].GetValue<string>();
                        retail.geography_name = getGeoCodeName(ws.Cells[nRow, 2].GetValue<string>().ToLower().Trim());
                        retail.adjustments = getAdjustments(ws.Cells[nRow, 5].GetValue<string>().ToLower().Trim());
                        retail.industry_class = ws.Cells[nRow, 4].GetValue<string>();
                        retail.value = ws.Cells[nRow, 12].GetValue<long>();

                         _context.Retails.Add(retail);
                        await _context.SaveChangesAsync();
                            
                        lstRetail.Add(retail);

                        nRetail++;
                    }

                    return new JsonResult(new {
                        Retail = nRetail
                    });
                }
            }

        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ImportGDP()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/GDP.xlsx")
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
                    var nGDP = 0;

                    //create a list containing all the debts already existing into the database
                    var lstGDPs = _context.GDPs.ToList();

                    for(int nRow = 206642; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var ref_date = ws.Cells[nRow, 1].GetValue<DateTime>();
                        var vec_id = ws.Cells[nRow, 11].GetValue<string>();

                        
                        var gdp = new GDP();
                        gdp.reference_date = ref_date;
                        gdp.vector_id = vec_id;

                        gdp.geography_name = ws.Cells[nRow, 2].GetValue<string>();
                        gdp.industry_classification = ws.Cells[nRow, 6].GetValue<string>();
                        gdp.prices = ws.Cells[nRow, 5].GetValue<string>();
                        gdp.value = ws.Cells[nRow, 13].GetValue<long>();
                        gdp.seasonal_adj = ws.Cells[nRow, 4].GetValue<string>();

                        _context.GDPs.Add(gdp);
                        await _context.SaveChangesAsync();
                            
                        lstGDPs.Add(gdp);

                        nGDP++;
                        
                    }

                    return new JsonResult(new {
                        Gdp = nGDP
                    });
                }
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ImportDebt()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Debt.xlsx")
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
                    var nDebt = 0;

                    //create a list containing all the debts already existing into the database
                    var lstDebts = _context.Debts.ToList();

                    //iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                        var ref_date = ws.Cells[nRow, 1].GetValue<DateTime>();
                        var vec_id = ws.Cells[nRow, 9].GetValue<string>();

                        var geo_name = getGeoCodeName(ws.Cells[nRow, 2].GetValue<string>().ToLower());

                        if(geo_name != "" && lstDebts.Where(c => c.Vector_id==vec_id && c.Reference_date == ref_date).Count() == 0)
                        {
                            var debt = new Debt();
                            debt.Reference_date = ref_date;
                            debt.Vector_id = vec_id;
                            debt.Geography_name = geo_name;

                            debt.DGUID = ws.Cells[nRow, 3].GetValue<string>();
                            debt.Central_gov_debt = ws.Cells[nRow, 4].GetValue<string>();
                            debt.Value = ws.Cells[nRow, 11].GetValue<long>();
                            
                            _context.Debts.Add(debt);
                            await _context.SaveChangesAsync();
                            
                            lstDebts.Add(debt);

                            nDebt++;
                        }
                    }

                    return new JsonResult(new {
                        Debt = nDebt
                    });
                }
            }
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult> ImportEmployment()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/Employment-male-2554.xlsx")
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
                    var nEmployment = 0;

                    //create a list containing all the cpis already existing into the database (t will be empty on first run)
                    var lstEmployments = _context.Employments.ToList();

                    //iterates through all rows, skipping the first one
                    for (int nRow = 2; nRow <= ws.Dimension.End.Row; nRow++)
                    {
                        var row = ws.Cells[nRow, 1 , nRow, ws.Dimension.End.Column];
                        var ref_data = ws.Cells[nRow, 1].GetValue<DateTime>();
                        var vec_id = ws.Cells[nRow, 13].GetValue<string>();

                        var geo_name = getGeoCodeName(ws.Cells[nRow, 2].GetValue<string>().ToLower());

                        if(geo_name != "" && lstEmployments.Where(c => c.VectorId==vec_id && c.ReferenceDate == ref_data).Count() == 0)
                        {
                            //create the CPI entity and fill it with the xslx data
                            var employment = new Employment();
                            employment.ReferenceDate = ref_data;
                            employment.VectorId = vec_id;
                            employment.GeoName = geo_name;

                            employment.Lfc = getLfcValue(ws.Cells[nRow, 4].GetValue<string>().ToLower().Trim());
                            employment.Sex = getSexValue(ws.Cells[nRow, 5].GetValue<string>().ToLower().Trim());
                            employment.AgeGroup = getAgeGroup(ws.Cells[nRow, 6].GetValue<string>().ToLower().Trim());

                            employment.UOM = ws.Cells[nRow, 9].GetValue<string>();
                            employment.ScalarFactor = ws.Cells[nRow, 11].GetValue<string>();
                            employment.Value = ws.Cells[nRow, 15].GetValue<decimal>();
                            
                            _context.Employments.Add(employment);
                            await _context.SaveChangesAsync();

                            lstEmployments.Add(employment);

                            nEmployment++;
                        }
                    }

                    return new JsonResult(new {
                        Employment = nEmployment
                    });
                }
            }
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

        private int getPrincipalStat(string industry)
        {
            switch(industry)
            {
                case "sales of goods manufactured (shipments)":
                    return 0;
                case "ratio of total inventory to sales":
                    return 1;
                default:
                    return -1;
            }
        }

        private int getAdjustments(string adj)
        {
            switch(adj)
            {
                case "unadjusted":
                    return 0;
                case "seasonally adjusted":
                    return 1;
                default:
                    return -1;
            }
        }

        private int getAgeGroup(string group)
        {
            switch(group)
            {
                case "15 years and over":
                    return 0;
                case "15 to 24 years":
                    return 1;
                case "25 years and over":
                    return 2;
                case "25 to 54 years":
                    return 3;
                case "55 years and over":
                    return 4;
                default:
                    return -1;
            }
        }

        private int getSexValue(string sex)
        {
            switch (sex)
            {
                case "both sexes":
                    return 0;
                case "males":
                    return 1;
                case "females":
                    return 2;
                default:
                    return -1;
            }
        }

        private int getLfcValue(string lfc)
        {
            switch (lfc)
            {
                case "population":
                    return 0;
                case "labour force":
                    return 1;
                case "employment":
                    return 2;
                case "full-time employment":
                    return 3;
                case "part-time employment":
                    return 4;
                case "unemployment":
                    return 5;
                case "unemployment rate":
                    return 6;
                case "participation rate":
                    return 7;
                case "employment rate":
                    return 8;
                default:
                    return -1;
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
                case "yukon":
                    return "YT";
                case "northwest territories":
                    return "NT";
                case "nunavut":
                    return "NU";
                default:
                    return geo_name;
            }
        }

    }
}