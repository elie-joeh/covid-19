using System.Collections.Generic;
using System.Linq;

namespace covid19.Data
{
    public class CityService : ICityService
    {
        public List<City> getAllCities()
        {
            return Data.Cities.ToList();
        }

        public List<City> GetCitiesBySearchName(string name)
        {
            List<City> allCities = Data.Cities.ToList();
            List<City> searchedCities = new List<City>();
            foreach (City city in allCities) {
                if(city.Name.Contains(name, System.StringComparison.CurrentCultureIgnoreCase)){
                    searchedCities.Add(city);
                }
            }

            return searchedCities;
        }

        public City getCityById(int id)
        {
            return Data.Cities.FirstOrDefault(n => n.Id == id);
        }

        public City getCityByName(string name)
        {
            return Data.Cities.FirstOrDefault(n => n.Name == name);
        }

        public Province getProinveOfCityByCity(int id)
        {
            City this_city = Data.Cities.FirstOrDefault(n => n.Id == id);
            return this_city.Province;
        }

        public Province getProvinceOfCityByName(string name)
        {
            City this_city = Data.Cities.FirstOrDefault(n => n.Name == name);
            return this_city.Province;
        }
    }
}