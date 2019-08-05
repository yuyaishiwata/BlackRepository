using Xamarin.Forms;

using System.Threading.Tasks;

using System.Diagnostics;

namespace Black.Views.Controls
{
    public partial class ImageWithInfo : ContentView
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(ImageWithInfo), Color.White);
        public static readonly BindableProperty BorderSizeProperty = BindableProperty.Create("BorderSize", typeof(int), typeof(ImageWithInfo), 1);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(int), typeof(ImageWithInfo), 7, propertyChanged: SetOutsideAndInsideCornerRadius);
        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(ImageWithInfo), string.Empty);
        public static readonly BindableProperty DescriptionColorProperty = BindableProperty.Create("DescriptionColor", typeof(Color), typeof(ImageWithInfo), Color.Silver);
        public static readonly BindableProperty DescriptionFontSizeProperty = BindableProperty.Create("DescriptionFontSize", typeof(double), typeof(ImageWithInfo), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
        public static readonly BindableProperty ImageHeightRequestProperty = BindableProperty.Create("ImageHeightRequest", typeof(int), typeof(ImageWithInfo), 120);
        public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create("ImageWidthRequest", typeof(int), typeof(ImageWithInfo), 120);
        public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageWithInfo), null);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(ImageWithInfo), string.Empty);
        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create("TitleColor", typeof(Color), typeof(ImageWithInfo), Color.White);
        public static readonly BindableProperty TitleFontSizeProperty = BindableProperty.Create("TitleFontSize", typeof(double), typeof(ImageWithInfo), Device.GetNamedSize(NamedSize.Large, typeof(Label)));

        int outsideCornerRadius = 7;
        public int OutsideCornerRadius
        {
            get => outsideCornerRadius;
            private set
            {
                outsideCornerRadius = value;
                OnPropertyChanged();
            }
        }

        int insideCornerRadius = 6;
        public int InsideCornerRadius
        {
            get => insideCornerRadius;
            private set
            {
                insideCornerRadius = value;
                OnPropertyChanged();
            }
        }

        bool isLoading = true;
        private bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public ImageWithInfo()
        {
            InitializeComponent();
            title.IsVisible = false;
            description.IsVisible = false;

            SetOutsideAndInsideCornerRadius(this, null, CornerRadius);

            LoadImageAsync();
        }

        private async Task LoadImageAsync()
        {
            await Task.Delay(300);
            if (image.IsLoading)
            {
                while (image.IsLoading)
                    await Task.Delay(100);
            }

            frame.IsVisible = true;
            indicator.IsRunning = false;
            indicator.IsVisible = false;
        }

        public static void SetOutsideAndInsideCornerRadius(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ImageWithInfo image))
                return;

            image.OutsideCornerRadius = (int)newValue == 0 ? 0 : (int)newValue;
            image.InsideCornerRadius = (int)newValue == 0 ? 0 : (int)newValue - image.BorderSize;
        }


        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public int BorderSize
        {
            get => (int)GetValue(BorderSizeProperty);
            set => SetValue(BorderSizeProperty, value);
        }

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set
            {
                description.IsVisible = !string.IsNullOrEmpty(value);
                SetValue(DescriptionProperty, value);
            }
        }

        public Color DescriptionColor
        {
            get => (Color)GetValue(DescriptionColorProperty);
            set => SetValue(DescriptionColorProperty, value);
        }

        public double DescriptionFontSize
        {
            get => (double)GetValue(DescriptionFontSizeProperty);
            set => SetValue(DescriptionFontSizeProperty, value);
        }

        public int ImageHeightRequest
        {
            get => (int)GetValue(ImageHeightRequestProperty);
            set => SetValue(ImageHeightRequestProperty, value);
        }

        public int ImageWidthRequest
        {
            get => (int)GetValue(ImageWidthRequestProperty);
            set => SetValue(ImageWidthRequestProperty, value);
        }

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                title.IsVisible = !string.IsNullOrEmpty(value); 
                SetValue(TitleProperty, value);
            }
        }

        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set => SetValue(TitleFontSizeProperty, value);
        }
    }
}
