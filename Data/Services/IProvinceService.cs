using System.Collections.Generic;

namespace covid19.Data
{
    public interface IProvinceService
    {
        List<Province> getAllProvinces();

        Province getProvinceById(int id);

        Province getProvinceByName(string name);

    }
}