using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;

using Xamarin.Forms;

using Black.Views.Controls;
using Black.Models;


namespace Black.Converters
{
    public class TracksToImageWithInfoListConverter : IValueConverter
    {
        public Command<string> TapCommand { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var images = new List<ImageWithInfo>();

            var tracks = value as Tracks;
            if (tracks?.Count <= 0)
                return null;

            foreach (Track track in tracks)
            {
                var image = new ImageWithInfo
                {
                    Title = track.Name,
                    TitleColor = Color.White,
                    Description = track.Artists[0].Name,
                    DescriptionColor = Color.Silver,
                    Source = track.Album.Images[1].Url,
                };

                image.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = TapCommand,
                    CommandParameter = track.Id
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
