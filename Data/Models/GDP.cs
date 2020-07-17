using System;
using System.ComponentModel.DataAnnotations;

namespace covid19.Data
{
    public class GDP
    {
        #region Constructor
        public GDP()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int id {get; set;}
        public DateTime reference_date {get; set;}
        public string geography_name {get; set;}
        public string seasonal_adj {get; set;}
        public string prices {get; set;}
        public string industry_classification {get; set;}
        public string vector_id {get; set;}
        public long value {get; set;}
        #endregion
    }
}