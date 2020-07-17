using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IRetailService
    {
        Task<IEnumerable<Retail>> GetRetails();
        Task<IEnumerable<Retail>> GetRetailByVector(string vector);
        Task<IEnumerable<Retail>> GetRetailByVectors(string vectors);
    }
}