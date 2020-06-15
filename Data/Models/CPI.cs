using System;

namespace covid19.Data
{
    public class CPI
    {
        public int Id {get; set;}
        public DateTime Reference_date {get; set;}
        public string Geography {get; set;}
        public string Vector_id {get; set;}
        public string Ppdg {get; set;}
        public float Value {get; set;}
    }
}