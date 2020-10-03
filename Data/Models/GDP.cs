using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        [Column("Vector_id", Order=1)]
        public string Vector_id { get; set; }

        [Key]
        [Column("Reference_date", Order=2)]
        [JsonProperty("refPer")]
        public DateTime Reference_date { get; set; } 

        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("value")]
        public double? Value { get; set; }

        [JsonProperty("decimals")]
        public int Decimals { get; set; } 

        [JsonProperty("scalarFactorCode")]
        public int ScalarFactorCode { get; set; } 

        [JsonProperty("releaseTime")]
        public string ReleaseTime { get; set; }
        #endregion
    }


    public class GDPData    {
        [JsonProperty("responseStatusCode")]
        public int ResponseStatusCode { get; set; } 
        [JsonProperty("productId")]
        public int ProductId { get; set; } 
        [JsonProperty("coordinate")]
        public string Coordinate { get; set; } 
        [JsonProperty("vectorId")]
        public string VectorId { get; set; }
        [JsonProperty("vectorDataPoint")]
        public List<GDP> Data { get; set; } 
    }

    public class GDPJson {
        [JsonProperty("status")]
        public string Status { get; set; } 
        [JsonProperty("object")]
        public GDPData AllData { get; set; } 
    }

}