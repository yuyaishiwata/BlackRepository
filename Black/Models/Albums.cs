using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;

namespace Black.Models
{
    public class Albums : Models<Album>
    {
        public string Title { get; set; } = string.Empty;

        public static async Task<Album> GetAlbumById(string albumId, string market = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("market", market);

            return await GetAsync<Album>($"/albums/{albumId}?{query}");
        }

        public static async Task<Albums> GetAlbumsByArtistId(string artistId, int limit = 10, int offset = 0, string market = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("limit", limit.ToString());
            query.Add("offset", offset.ToString());
            query.Add("market", market);

            Paging<Album> paging = await GetAsync<Paging<Album>>($"/artists/{artistId}/albums?{query}");
            var albums = new Albums();
            albums.LoadPaging(paging);

            return albums;
        }

        public static async Task<Albums> GetNewReleasedAlbums(int limit = 10, int offset = 0, string market = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("limit", limit.ToString());
            query.Add("offset", offset.ToString());
            query.Add("market", market);

            AlbumsPaging wrap = await GetAsync<AlbumsPaging>($"/browse/new-releases?{query}");

            var albums = new Albums();
            albums.LoadPaging(wrap.Paging);

            return albums;
        }
    }
}