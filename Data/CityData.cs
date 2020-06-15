using System.Collections.Generic;

namespace covid19.Data
{
    public class CityData
    {
        public static List<City> Cities => allCities;

        static List<City> allCities = new List<City>()
        {
            new City()
            {
                Id=1,
                Name="Montreal",
                Infected=1500,
                Dead=100,
                Province = new Province {
                    Id=1,
                    Name="Quebec",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=6,
                Name="Mont Tremblant",
                Infected=15,
                Dead=4,
                Province = new Province {
                    Id=1,
                    Name="Quebec",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=4,
                Name="Magog",
                Infected=10,
                Dead=3,
                Province = new Province {
                    Id=1,
                    Name="Quebec",
                    Infected=15000,
                    Dead=400
                }
            },
             new City()
            {
                Id=2,
                Name="Toronto",
                Infected=2000,
                Dead=150,
                Province = new Province {
                    Id=1,
                    Name="Ontario",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=5,
                Name="York",
                Infected=50,
                Dead=6,
                Province = new Province {
                    Id=1,
                    Name="Ontario",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=3,
                Name="Calgary",
                Infected=700,
                Dead=100,
                Province = new Province {
                    Id=1,
                    Name="Alberta",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=7,
                Name="Vancouver",
                Infected=1000,
                Dead=200,
                Province=new Province {
                    Id=1,
                    Name="British Columbia",
                    Infected=15000,
                    Dead=400
                }
            },
            new City()
            {
                Id=8,
                Name="Edmonton",
                Infected=400,
                Dead=50,
                Province=new Province {
                    Id=1,
                    Name="Alberta",
                    Infected=15000,
                    Dead=400
                }
            }
        };
    }
}