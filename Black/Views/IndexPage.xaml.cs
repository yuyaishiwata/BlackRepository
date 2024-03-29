﻿using System;

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

            Application.Current.Resources["browse_page"] = this;

            InitializeComponent();
        }

        public void Logout(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new AuthPage(true));
        }
    }
}
