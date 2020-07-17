using System;
using System.ComponentModel.DataAnnotations;

namespace covid19.Data
{
    public class Debt
    {
        #region Constructor
        public Debt()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int Id {get; set;}
        public DateTime Reference_date {get; set;}
        public string DGUID {get; set;}
        public string Vector_id {get; set;}
        public string Geography_name {get; set;}
        public string Central_gov_debt {get; set;}
        public long Value {get; set;}
        #endregion
    }
}