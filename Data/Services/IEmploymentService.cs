using System.Collections.Generic;
using System.Threading.Tasks;

namespace covid19.Data
{
    public interface IEmploymentService
    {
        Task<IEnumerable<Employment>> GetEmployments();
        Task<IEnumerable<Employment>> GetEmploymentsByGeo(string geoName);
        Task<IEnumerable<Employment>> GetEmploymentsByLfc(int lfc);
        Task<IEnumerable<Employment>> GetEmploymentsBySex(int sex);
        Task<IEnumerable<Employment>> GetEmploymentByGroup(int groupNumber);
        Task<IEnumerable<Employment>> GetEmploymentByLfcSexGroup(int lfc, int sex, int groupNumber);
        Task<IEnumerable<Employment>> GetEmploymentBySexGroup(int sex, int groupNumber);
        Task<IEnumerable<Employment>> GetEmploymentBySexesGroup(int sex, int groupNumber);
        Task<IEnumerable<Employment>> GetEmploymentByLfcSexGroups(int lfc, int sex, int groupNumbers);
    }
}