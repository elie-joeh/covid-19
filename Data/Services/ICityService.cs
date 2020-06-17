using System.Collections.Generic;

namespace covid19.Data
{
    public interface ICityService
    {
        List<City> getAllCities();
        List<City> GetCitiesBySearchName(string name);
        City getCityById(int id);
        City getCityByName(string name);
        Geography getProvinceOfCityByName(string name);
        Geography getProinveOfCityByCity(int id);
    }
}