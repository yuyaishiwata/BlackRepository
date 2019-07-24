using Xamarin.Forms;

using Black.ViewModels;

namespace Black.Views
{
    public partial class TrackPage : ContentPage
    {
        TrackViewModel viewModel;

        public TrackPage(string trackId)
        {
            BindingContext = viewModel = new TrackViewModel(Navigation, trackId);

            InitializeComponent();

            pb.ProgressTo(1, 30000, Easing.Linear);

        }
    }
}