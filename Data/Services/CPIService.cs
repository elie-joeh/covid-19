using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using covid19.Data;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace covid19.Data
{
    public class CPIService : ICPIService
    {
        private readonly ApplicationDbContext _context;

        public CPIService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CPI>> getAllCPIs()
        {
            return await _context.CPIs.ToListAsync();
        }
    }
}