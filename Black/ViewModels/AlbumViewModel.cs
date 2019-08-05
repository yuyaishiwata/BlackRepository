using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using Black.Models;

namespace Black.ViewModels
{
    public class AlbumViewModel : ApplicationViewModel
    {
        Album album = new Album();
        public Album Album { get => album; set => SetProperty(ref album, value); }

        Albums relatedAlbums = new Albums();
        public Albums RelatedAlbums { get => relatedAlbums; set => SetProperty(ref relatedAlbums, value); }

        public AlbumViewModel(INavigation navigation, string albumId)
        {
            Navigation = navigation;

            InitializeAsync(albumId);
        }

        public async Task InitializeAsync(string albumId)
        {
            IsRunning = true;

            Album = await Albums.GetAlbumById(albumId);
            RelatedAlbums = await Albums.GetAlbumsByArtistId(Album.Artists[0].Id);

            IsRunning = false;
        }
    }
}
