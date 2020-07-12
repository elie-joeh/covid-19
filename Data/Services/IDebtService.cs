using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IDebtService
    {
        Task<IEnumerable<Debt>> GetDebts();
        Task<IEnumerable<Debt>> GetDebtsByVector(string vector_id);
        Task<IEnumerable<Debt>> GetDebtsByVectors(string vector_ids);
    }
}