using System.Collections.Generic;

namespace covid19.Data
{
    public interface ICityService
    {
        List<City> getAllCities();
        List<City> GetCitiesBySearchName(string name);
        City getCityById(int id);
        City getCityByName(string name);
        Province getProvinceOfCityByName(string name);
        Province getProinveOfCityByCity(int id);
    }
}