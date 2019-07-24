using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using Black.Models;
using Black.Views;

namespace Black.ViewModels
{
    public class TrackViewModel : ApplicationViewModel
    {
        Track track = new Track();
        public Track Track { get => track; set => SetProperty(ref track, value); }

        Artist artist = new Artist();
        public Artist Artist { get => artist; set => SetProperty(ref artist, value); }


        public new Command<string> NavigateArtistPageCommand { get; private set; }

        public TrackViewModel(INavigation navigation, string trackId)
        {
            Navigation = navigation;
            NavigateArtistPageCommand = new Command<string>(ExecuteNavigateArtistPageCommand);

            InitializeAsync(trackId);
        }

        public async Task InitializeAsync(string trackId)
        {
            Track = (await Tracks.GetTracksById(trackId)).FirstOrDefault();
            Artist = await Artists.GetArtistByIdAsync(Track.Artists[0].Id);
        }

        public new async void ExecuteNavigateArtistPageCommand(string artistId)
        {
            await Navigation.PopModalAsync();

            var indexPage = Application.Current.Resources["browse_page"] as Page;
            await indexPage.Navigation.PushAsync(new ArtistPage(artistId));
        }
    }
}
