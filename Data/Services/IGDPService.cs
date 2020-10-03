using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IGDPService
    {
        Task<IEnumerable<GDP>> GetGDPs();
        Task<IEnumerable<GDP>> GetGDPAllIndustry();
        Task<IEnumerable<GDP>> GetGDPsByVector(string vector_id);
        Task<IEnumerable<GDP>> GetGDPsByVectors(string vector_ids);
    }
}