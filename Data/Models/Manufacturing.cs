using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covid19.Data
{
    public class Manufacturing
    {

        #region Constructor
        public Manufacturing()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int Id {get; set;}
        public DateTime Reference_date{get; set;}
        public string Geography_name{get; set;}
        public string Vector_id{get; set;}

        /// <summary>
        /// 0 --> sales of good manufactured
        /// 1 --> Ratio of total inventory to sales
        /// </summary>
        public int Principal_statistics{get; set;}
        /// <summary>
        /// 0 --> unadjusted
        /// 1 --> seasonally adjusted
        /// </summary>
        public int Adjustment;
        public string Industry_classification{get; set;}
        [Column(TypeName = "decimal(10,2)")]
        /// <summary>
        /// The actual data value
        /// </summary>
        public decimal Value {get; set;}
        #endregion
    }
}