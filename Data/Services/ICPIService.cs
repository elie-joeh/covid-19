using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface ICPIService
    {
        Task<IEnumerable<CPI>> getCPIByPpdg(string ppdg);
        Task<IEnumerable<CPI>> getCPIByGeo(string geographyName);
        Task<IEnumerable<CPI>> getCPIByGeosByPPDG(string geos, string ppdg);
        Task<IEnumerable<CPI>> getCPIs();
    }
}