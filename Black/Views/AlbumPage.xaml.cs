using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Black.ViewModels;
using Black.Converters;

namespace Black.Views
{
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel viewModel;

        public AlbumPage(string albumId)
        {
            BindingContext = viewModel = new AlbumViewModel(Navigation, albumId);
            Resources.Add("viewModel", viewModel);
            Resources.Add("albumsToImages", new AlbumsToImageWithInfoListConverter { TapCommand = viewModel.NavigateAlbumPageCommand });
            Resources.Add("millisecondsToFormated", new MillisecondsToTimeSpanFormatConverter());

            InitializeComponent();
        }
    }
}
