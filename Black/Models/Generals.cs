using System;
using Newtonsoft.Json;

namespace Black.Models
{
    public class ArtistList
    {
        [JsonProperty("artists")]
        public Artists Artists { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }


    public class Copyright
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PlaylistTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("track")]
        public Track Track { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }
    }
}
