using Xamarin.Forms;

using Black.Converters;
using Black.ViewModels;

namespace Black.Views
{
    public partial class IndexPage : ContentPage
    {
        private IndexViewModel viewModel;

        public IndexPage()
        {
            BindingContext = viewModel = new IndexViewModel(Navigation);
            Resources.Add("tracksToImages", new TracksToImageWithInfoListConverter { TapCommand = viewModel.PushModalPlayerPageAsyncCommand });
            Resources.Add("albumsToImages", new AlbumsToImageWithInfoListConverter { TapCommand = viewModel.NavigateAlbumPageCommand });

            InitializeComponent();
        }
    }
}
