using Xamarin.Forms;

using Black.Converters;
using Black.ViewModels;

namespace Black.Views
{
    public partial class TrackPage : ContentPage
    {
        TrackViewModel viewModel;

        public TrackPage(string trackId)
        {
            BindingContext = viewModel = new TrackViewModel(Navigation, trackId);
            Resources.Add("tracksToImages", new TracksToImageWithInfoListConverter { TapCommand = viewModel.ReloadTrackCommand });

            InitializeComponent();

            pb.ProgressTo(1, 30000, Easing.Linear);

        }
    }
}