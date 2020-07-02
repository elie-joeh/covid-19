
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace covid19.Data
{
    public class Employment
    {
        #region Constructor
        public Employment()
        {

        }
        #endregion

        #region Properties

        [Key]
        /// <summary>
        /// The unique Id and primary key for the Employment
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// Vector id representing the employment value for specific reference date and geography
        /// </summary>
        public string VectorId {get; set;}
        /// <summary>
        /// reference date
        /// </summary>
        public DateTime ReferenceDate {get; set;}
        /// <summary>
        /// The geography name for which the data represents
        /// </summary>
        public string GeoName {get; set;}
        /// <summary>
        /// The Labor Force Characterisitcs for the data
        /// 0 --> Population
        /// 1 --> Labour Force
        /// 2 --> Employment
        /// 3 --> Full-time Employment
        /// 4 --> Part-time Employment
        /// 5 --> Unemployment
        /// 6 --> Unemployment Rate
        /// 7 --> Participation Rate
        /// 8 --> Employment Rate
        /// </summary>
        public int Lfc {get; set;}
        /// <summary>
        /// The sex for the data
        /// 0 --> both sexes
        /// 1 --> Male
        /// 2 --> Female
        /// </summary>
        public int Sex {get; set;}
        /// <summary>
        /// The considered age group for the data
        /// 0 --> 15 years and above
        /// 1 --> 15 to 24 years
        /// 2 --> 25 years and over
        /// 3 --> 25 to 54 years
        /// 4 --> 55 years and over
        /// </summary>
        public int AgeGroup {get; set;}
        /// <summary>
        /// The data metric
        /// </summary>
        public string UOM {get; set;}
        /// <summary>
        /// The value scale factor
        /// </summary>
        public string ScalarFactor {get; set;}

        [Column(TypeName = "decimal(7,2)")]
        /// <summary>
        /// The actual data value
        /// </summary>
        public decimal Value {get; set;}
        #endregion
    }
}