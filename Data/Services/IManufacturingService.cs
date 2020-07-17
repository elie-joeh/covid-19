using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IManufacturingService
    {
        Task<IEnumerable<Manufacturing>> GetManufacturings();
        Task<IEnumerable<Manufacturing>> GetManufacturingByVector(string vector);
        Task<IEnumerable<Manufacturing>> GetManufacturingByVectors(string vectors);
    }
}