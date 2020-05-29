using System.Collections.Generic;
using System.Linq;

namespace covid19.Data
{
    public class ProvinceService : IProvinceService
    {
        public List<Province> getAllProvinces()
        {
            return Data.Provinces.ToList();
        }

        public Province getProvinceById(int id)
        {
            return Data.Provinces.FirstOrDefault(n => n.Id == id);
        }

        public Province getProvinceByName(string name)
        {
            return Data.Provinces.FirstOrDefault(n => n.Name == name);
        }
    }
}