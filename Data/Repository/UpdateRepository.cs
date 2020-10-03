using System;
using System.Text.Json.Serialization;

namespace covid19
{
    public class UpdateRepository
    {
        [JsonPropertyName("name")]
        public string Name {get; set;}

        [JsonPropertyName("full_name")]
        public string FullName {get; set;}
    }
}