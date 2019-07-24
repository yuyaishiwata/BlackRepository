using Newtonsoft.Json;

namespace Black.Models
{
    public class Category
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("icons")]
        public Images Icons { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
