using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;

namespace Black.Models
{
    public class Tracks : Models<Track>
    {
        public string Title { get; set; } = string.Empty;

        public static async Task<Track> GetTracksById(string id, string market = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("market", market);

            return await GetAsync<Track>($"/tracks/{id}");
        }

        public static async Task<Tracks> GetTopTracksByArtistId(string artistId, string country = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("country", country);

            return (await GetAsync<TrackList>($"/artists/{artistId}/top-tracks?{query}")).Tracks;
        }

        public static async Task<Tracks> GetTracksByPlaylistId(string playlistId, int limit = 10, int offset = 0, string market = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("limit", limit.ToString());
            query.Add("offset", offset.ToString());
            query.Add("market", market);

            Paging<PlaylistTrack> paging = await GetAsync<Paging<PlaylistTrack>>($"/playlists/{playlistId}/tracks?{query}");
            var tracks = new Tracks();
            tracks.LoadPaging(paging, pTrack => pTrack.Track);

            return tracks;
        }
    }
}
