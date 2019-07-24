using System;
using Newtonsoft.Json;

namespace Black.Models
{
    public class Track
    {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
    }
}
