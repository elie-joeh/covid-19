using System.Collections.Generic;

namespace covid19.Data
{
    public class ProvinceData
    {
        public static List<Province> Provinces => allProvinces;    

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