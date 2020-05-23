using System.Collections.Generic;

namespace covid19.Data
{
    public class Data
    {
        public static List<Province> Provinces => allProvinces;
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
        

        static List<Province> allProvinces = new List<Province>()
        {

            new Province(){
                Id=1,
                Name="Quebec",
                Infected=15000,
                Dead=400
            },
            new Province(){
                Id=2,
                Name="Ontario",
                Infected=13000,
                Dead= 250
            },
            new Province()
            {
                Id=3,
                Name="British Columbia",
                Infected=11000,
                Dead=300
            },
            new Province()
            {
                Id=4,
                Name="Yukon",
                Infected=1550,
                Dead=20
            },
            new Province()
            {
                Id=5,
                Name="Alberta",
                Infected=5000,
                Dead=110
            },
            new Province()
            {
                Id=6,
                Name="Prince Edward Island",
                Infected=1000,
                Dead=50
            },
            new Province()
            {
                Id=7,
                Name="Manitoba",
                Infected=3000,
                Dead=200
            },
            new Province()
            {
                Id=8,
                Name="Nova Scotia",
                Infected=5000,
                Dead=100
            },
            new Province()
            {
                Id=9,
                Name="New Brunswick",
                Infected=1250,
                Dead=30
            },
            new Province()
            {
                Id=10,
                Name="Newfoundland and Labrador",
                Infected=988,
                Dead=15
            },
            new Province()
            {
                Id=11,
                Name="Saskatchewan",
                Infected=2000,
                Dead=70
            },
            new Province()
            {
                Id=12,
                Name="Nunavut",
                Infected=13,
                Dead=5
            },
            new Province()
            {
                Id=13,
                Name="Northwest Territories",
                Infected=5,
                Dead=1
            }    
        };

        //Provincessssss
        static Province Quebec = new Province(){
                Id=1,
                Name="Quebec",
                Infected=15000,
                Dead=400
            };
        
        static Province Ontario= new Province()
            {
                Id=2,
                Name="Ontario",
                Infected=13000,
                Dead=350
            };

        static Province British_Columbia = new Province()
            {
                Id=3,
                Name="British Columbia",
                Infected=11000,
                Dead=300
            };

        static Province Yukon = new Province()
            {
                Id=4,
                Name="Yukon",
                Infected=1550,
                Dead=20
            };

        static Province Alberta = new Province()
            {
                Id=5,
                Name="Alberta",
                Infected=5000,
                Dead=110
            };

        static Province Prince_Edward_Island = new Province()
            {
                Id=6,
                Name="Prince Edward Island",
                Infected=1000,
                Dead=50
            };

        static Province Manitoba =  new Province()
            {
                Id=7,
                Name="Manitoba",
                Infected=3000,
                Dead=200
            };
        
        static Province Nova_Scotia = new Province()
            {
                Id=8,
                Name="Nova Scotia",
                Infected=5000,
                Dead=100
            };

        static Province New_Brunswick = new Province()
            {
                Id=9,
                Name="New Brunswick",
                Infected=1250,
                Dead=30
            };

        static Province NL = new Province()
            {
                Id=10,
                Name="Newfoundland and Labrador",
                Infected=988,
                Dead=15
            };

        static Province Saskatchewan = new Province()
            {
                Id=11,
                Name="Saskatchewan",
                Infected=2000,
                Dead=70
            }; 

        static Province Nunavut = new Province()
            {
                Id=12,
                Name="Nunavut",
                Infected=13,
                Dead=5
            };
        static Province NT = new Province()
            {
                Id=13,
                Name="Northwest Territories",
                Infected=5,
                Dead=1
            };
    }
}