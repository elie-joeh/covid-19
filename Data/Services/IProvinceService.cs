using System.Collections.Generic;

namespace covid19.Data
{
    public interface IProvinceService
    {
        List<Geography> getAllProvinces();

        Geography getProvinceByName(string name);

    }
}