using Xamarin.Forms;

using Black.Models;
using Black.Views;

namespace Black.ViewModels
{
    public abstract class ApplicationViewModel : BaseViewModel
    {
        public Command<string> NavigateArtistPageCommand { get; private set; }
        public Command<string> NavigateAlbumPageCommand { get; private set; }

        public Command<string> PushModalPlayerPageAsyncCommand { get; private set; }
        public Command PopModalPlayerPageAsyncCommand { get; private set; }


        bool IsPlayerVisible { get; set; } = false;
        public void TogglePlayerVisible() => IsPlayerVisible = !IsPlayerVisible;

        public Command NavigateCommand;


        string title = string.Empty;
        public string Title { get => title; set => SetProperty(ref title, value); }


        protected ApplicationViewModel()
        {
            //コマンド定義
            NavigateCommand = new Command<Page>(async (Page page) => await Navigation.PushAsync(page));

            NavigateAlbumPageCommand = new Command<string>(ExecuteNavigateAlbumPageCommand);
            NavigateArtistPageCommand = new Command<string>(ExecuteNavigateArtistPageCommand);

            PushModalPlayerPageAsyncCommand = new Command<string>(ExecutePushModalPlayerPageAsync);
            PopModalPlayerPageAsyncCommand = new Command(ExecutePopModalPlayerPageAsync);

            Black.Models.Models.Initialize((AuthorizationCodeAuth)Application.Current.Resources["auth"]);
        }

        public async void ExecuteNavigateAlbumPageCommand(string albumId) => await Navigation.PushAsync(new AlbumPage(albumId));
        public async void ExecuteNavigateArtistPageCommand(string artistId) => await Navigation.PushAsync(new ArtistPage(artistId));
        public async void ExecutePushModalPlayerPageAsync(string trackId) => await Navigation.PushModalAsync(new TrackPage(trackId));
        public async void ExecutePopModalPlayerPageAsync() => await Navigation.PopModalAsync();
    }
}
