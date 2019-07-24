using System.Threading.Tasks;

namespace Black.Models
{
    public class Artists : Models<Artist>
    {
        public static async Task<Artist> GetArtistByIdAsync(string id)
        {
            return await GetAsync<Artist>($"/artists/{id}");
        }

        public static async Task<Artists> GetRelatedArtistsById(string id)
        {
            return (await GetAsync<ArtistList>($"/artists/{id}/related-artists")).Artists;
        }
    }
}
