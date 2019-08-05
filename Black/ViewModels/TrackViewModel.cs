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

        Tracks relatedTracks = new Tracks();
        public Tracks RelatedTracks { get => relatedTracks; set => SetProperty(ref relatedTracks, value); }


        public new Command<string> NavigateArtistPageCommand { get; private set; }
        public Command<string> ReloadTrackCommand { get; private set; }

        public TrackViewModel(INavigation navigation, string trackId)
        {
            Navigation = navigation;
            NavigateArtistPageCommand = new Command<string>(ExecuteNavigateArtistPageCommand);
            ReloadTrackCommand = new Command<string>(ExecuteReloadTrackCommand);

            InitializeAsync(trackId);
        }

        public async Task InitializeAsync(string trackId)
        {
            IsRunning = true;

            Track = await Tracks.GetTracksById(trackId);
            Artist = await Artists.GetArtistByIdAsync(Track.Artists[0].Id);
            RelatedTracks = await Tracks.GetTopTracksByArtistId(Track.Artists[0].Id, "JP");

            IsRunning = false;
        }

        public new async void ExecuteNavigateArtistPageCommand(string artistId)
        {
            await Navigation.PopModalAsync();

            var indexPage = Application.Current.Resources["browse_page"] as Page;
            await indexPage.Navigation.PushAsync(new ArtistPage(artistId));
        }

        public new async void ExecuteReloadTrackCommand(string trackId)
        {
            await Navigation.PopModalAsync();

            var indexPage = Application.Current.Resources["browse_page"] as Page;
            await indexPage.Navigation.PushModalAsync(new TrackPage(trackId));
        }
    }
}
