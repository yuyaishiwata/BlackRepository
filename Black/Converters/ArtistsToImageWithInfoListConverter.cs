using System;
using System.Collections.Generic;
using System.Globalization;

using Xamarin.Forms;

using Black.Views.Controls;
using Black.Models;


namespace Black.Converters
{
    public class ArtistsToImageWithInfoListConverter : IValueConverter
    {
        public Command<string> TapCommand { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var images = new List<ImageWithInfo>();

            var artists = value as Artists;
            if (!(artists?.Count > 0))
                return null;

            foreach (Artist artist in artists)
            {
                var image = new ImageWithInfo
                {
                    Title = artist.Name,
                    TitleColor = Color.White,
                    Source = artist.Images?.Count > 0 ? artist.Images[1].Url : string.Empty
                };

                image.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = TapCommand,
                    CommandParameter = artist.Id
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
