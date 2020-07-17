using System;
using System.ComponentModel.DataAnnotations;

namespace covid19.Data
{
    public class Retail
    {
        #region Constructor
        public Retail()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int id {get; set;}
        public DateTime reference_date {get; set;}
        public string geography_name {get; set;}
        public string industry_class {get; set;}
        /// <summary>
        /// unadjusted --> 0
        /// seasonally adjusted --> 1 
        /// </summary>
        public int adjustments {get; set;}
        public long value {get; set;}
        public string vector_id {get; set;}
        #endregion
    }
}