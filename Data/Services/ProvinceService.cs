using System.Collections.Generic;
using System.Linq;

namespace covid19.Data
{
    public class ProvinceService : IProvinceService
    {
        public List<Geography> getAllProvinces()
        {
            return ProvinceData.Provinces.ToList();
        }

        public Geography getProvinceByName(string name)
        {
            return ProvinceData.Provinces.FirstOrDefault(n => n.Name == name);
        }
    }
}