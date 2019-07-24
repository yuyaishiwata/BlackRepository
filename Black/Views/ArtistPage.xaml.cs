using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

using Black.ViewModels;
using Black.Converters;

namespace Black.Views
{
    public partial class ArtistPage : ContentPage
    {
        public ArtistViewModel viewModel { get; private set; }

        public ArtistPage(string artistId)
        {
            BindingContext = viewModel = new ArtistViewModel(Navigation, artistId);
            Resources.Add("albumsToImages", new AlbumsToImageWithInfoListConverter { TapCommand = viewModel.NavigateAlbumPageCommand });
            Resources.Add("artistsToImages", new ArtistsToImageWithInfoListConverter { TapCommand = viewModel.NavigateArtistPageCommand });

            InitializeComponent();
        }
    }
}
