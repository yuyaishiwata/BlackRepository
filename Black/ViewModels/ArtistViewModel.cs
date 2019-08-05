using System.Threading.Tasks;

using Xamarin.Forms;

using Black.Models;

namespace Black.ViewModels
{
    public class ArtistViewModel : ApplicationViewModel
    {
        Artist artist = new Artist();
        public Artist Artist { get => artist; set => SetProperty(ref artist, value); }

        Artists relatedArtists = new Artists();
        public Artists RelatedArtists { get => relatedArtists; set => SetProperty(ref relatedArtists, value); }

        Albums artistsAlbums = new Albums();
        public Albums ArtistsAlbums { get => artistsAlbums; set => SetProperty(ref artistsAlbums, value); }

        public ArtistViewModel(INavigation navigation, string artistId)
        {
            Navigation = navigation;

            InitializeAsync(artistId);
        }

        public async Task InitializeAsync(string artistId)
        {
            IsRunning = true;

            Artist = await Artists.GetArtistByIdAsync(artistId);
            ArtistsAlbums = await Albums.GetAlbumsByArtistId(artistId, 20, 0, "JP");
            RelatedArtists = await Artists.GetRelatedArtistsById(artistId);

            Title = Artist.Name;

            IsRunning = false;
        }
    }
}
