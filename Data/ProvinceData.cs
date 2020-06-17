using System.Collections.Generic;

namespace covid19.Data
{
    public class ProvinceData
    {
        public static List<Geography> Provinces => allProvinces;    

        static List<Geography> allProvinces = new List<Geography>()
        {

            new Geography(){
                Name="Quebec",
                Infected=15000,
                Dead=400
            },
            new Geography(){
                Name="Ontario",
                Infected=13000,
                Dead= 250
            },
            new Geography()
            {
                Name="British Columbia",
                Infected=11000,
                Dead=300
            },
            new Geography()
            {
                Name="Yukon",
                Infected=1550,
                Dead=20
            },
            new Geography()
            {
                Name="Alberta",
                Infected=5000,
                Dead=110
            },
            new Geography()
            {
                Name="Prince Edward Island",
                Infected=1000,
                Dead=50
            },
            new Geography()
            {
                Name="Manitoba",
                Infected=3000,
                Dead=200
            },
            new Geography()
            {
                Name="Nova Scotia",
                Infected=5000,
                Dead=100
            },
            new Geography()
            {
                Name="New Brunswick",
                Infected=1250,
                Dead=30
            },
            new Geography()
            {
                Name="Newfoundland and Labrador",
                Infected=988,
                Dead=15
            },
            new Geography()
            {
                Name="Saskatchewan",
                Infected=2000,
                Dead=70
            },
            new Geography()
            {
                Name="Nunavut",
                Infected=13,
                Dead=5
            },
            new Geography()
            {
                Name="Northwest Territories",
                Infected=5,
                Dead=1
            }    
        };

    }
}