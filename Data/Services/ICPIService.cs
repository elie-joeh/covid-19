using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface ICPIService
    {
        Task<IEnumerable<CPI>> getAllCPIs();

    }
}