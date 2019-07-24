using System;
using System.Collections.Generic;
using System.Globalization;

using Xamarin.Forms;

using Black.Views.Controls;
using Black.Models;


namespace Black.Converters
{
    public class AlbumsToImageWithInfoListConverter : IValueConverter
    {
        public Command<string> TapCommand { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var images = new List<ImageWithInfo>();

            var albums = value as Albums;
            if (!(albums?.Count > 0))
                return null;

            foreach (Album album in albums)
            {
                var image = new ImageWithInfo
                {
                    Title = album.Name,
                    TitleColor = Color.White,
                    Description = album.Artists?.Count > 0 ? album.Artists[0].Name : string.Empty,
                    DescriptionColor = Color.Silver,
                    Source = album.Images?.Count > 0 ? album.Images[1].Url : string.Empty,
                };

                image.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = TapCommand,
                    CommandParameter = album.Id
                });

                images.Add(image);
            }

            return images;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
