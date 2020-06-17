using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covid19.Data
{
    public class CPI
    {
        #region Constructor
        public CPI()
        {

        }
        #endregion

        #region Properties
        [Key]
        /// <summary>
        /// The unique Id and primary key for the CPI
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// The reference date for CPI economic data
        /// </summary>
        public DateTime Reference_date {get; set;}
        /// <summary>
        /// The id referencing the geo id
        /// </summary>
        public string DGUID {get; set;}
        /// <summary>
        /// The vector ID provided by statcan
        /// </summary>
        public string Vector_Id {get; set;}
        /// <summary>
        /// Products and Product Groups
        /// </summary>
        public string Ppdg {get; set;}
        /// <summary>
        /// The coordinate value provided by statcan
        /// </summary>
        [Column(TypeName = "decimal(7,4)")]
        public decimal Coordinate {get; set;}
        /// <summary>
        /// The CPI value
        /// </summary>
        [Column(TypeName = "decimal(7,4)")]
        public decimal Value {get; set;}
        #endregion

        #region Relations
        /// <summary>
        /// The Geography name (foreign key)
        /// </summary>
        public string GeographyName {get; set;}
        public Geography Geography {get; set;}
        #endregion
        
    }
}