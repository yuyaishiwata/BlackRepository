using System.Threading.Tasks;

using Xamarin.Forms;

using Black.Models;

namespace Black.ViewModels
{
    public class IndexViewModel : ApplicationViewModel
    {
        Tracks topChartOfJapan = new Tracks();
        public Tracks TopChartOfJapan { get => topChartOfJapan; set => SetProperty(ref topChartOfJapan, value); }

        Tracks topChart = new Tracks();
        public Tracks TopChart { get => topChart; set => SetProperty(ref topChart, value); }

        Tracks bazzedTracks = new Tracks();
        public Tracks BazzedTracks { get => bazzedTracks; set => SetProperty(ref bazzedTracks, value); }

        Albums newReleases = new Albums();
        public Albums NewReleases { get => newReleases; set => SetProperty(ref newReleases, value); }

        //コンストラクタ
        public IndexViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "ホーム";

            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            IsRunning = true;

            TopChartOfJapan = await Tracks.GetTracksByPlaylistId("37i9dQZEVXbKXQ4mDTEBXq", 15, 0, "JP");
            TopChartOfJapan.Title = "トップチャート (日本)";

            TopChart = await Tracks.GetTracksByPlaylistId("37i9dQZEVXbMDoHDwVN2tF", 15, 0, "JP");
            TopChart.Title = "トップチャート (グローバル)";

            BazzedTracks = await Tracks.GetTracksByPlaylistId("37i9dQZEVXbINTEnbFeb8d", 15, 0, "JP");
            BazzedTracks.Title = "人気急上昇";

            NewReleases = await Albums.GetNewReleasedAlbums(20, 0, "JP");
            NewReleases.Title = "ニューリリース";

            IsRunning = false;
        }
    }
}
