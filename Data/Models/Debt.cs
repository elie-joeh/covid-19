using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covid19.Data
{
    public class Debt    {

        #region Constructor
        public Debt()
        {

        }
        #endregion

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
    }

    public class DebtData    {
        [JsonProperty("responseStatusCode")]
        public int ResponseStatusCode { get; set; } 
        [JsonProperty("productId")]
        public int ProductId { get; set; } 
        [JsonProperty("coordinate")]
        public string Coordinate { get; set; } 
        [JsonProperty("vectorId")]
        public string VectorId { get; set; }
        [JsonProperty("vectorDataPoint")]
        public List<Debt> Data { get; set; } 
    }

    public class DebtJson {
        [JsonProperty("status")]
        public string Status { get; set; } 
        [JsonProperty("object")]
        public DebtData AllData { get; set; } 
    }
}