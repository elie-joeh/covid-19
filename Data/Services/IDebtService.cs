using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IDebtService
    {
        Task<IEnumerable<Debt>> GetNetDebt();
    }
}