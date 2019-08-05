using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;

using Xamarin.Forms;

namespace Black.Views.Controls
{
    public partial class GridImagesView : ContentView
    {
        public static readonly BindableProperty BorderSizeProperty = BindableProperty.Create("BorderSize", typeof(int), typeof(GridImagesView), 3);
        public static readonly BindableProperty ColumnHeightProperty = BindableProperty.Create("ColumnHeight", typeof(int), typeof(GridImagesView), 10);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(int), typeof(GridImagesView), 5);
        public static readonly BindableProperty DescriptionFontSizeProperty = BindableProperty.Create("DescriptionFontSize", typeof(double), typeof(ImageWithInfo), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
        public static readonly BindableProperty ImageHeightRequestProperty = BindableProperty.Create("ImageHeightRequest", typeof(int), typeof(GridImagesView), 120);
        public static readonly BindableProperty ImagesTitleFontSizeProperty = BindableProperty.Create("ImagesTitleFontSize", typeof(double), typeof(ImageWithInfo), Device.GetNamedSize(NamedSize.Large, typeof(Label)));
        public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create("ImageWidthRequest", typeof(int), typeof(GridImagesView), 120);
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(ScrollOrientation), typeof(GridImagesView), ScrollOrientation.Horizontal);
        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create("RowHeight", typeof(int), typeof(GridImagesView), 1);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(GridImagesView), string.Empty);
        public static readonly BindableProperty TitleFontSizeProperty = BindableProperty.Create("TitleFontSize", typeof(double), typeof(ImageWithInfo), Device.GetNamedSize(NamedSize.Large, typeof(Label)));
        public static readonly BindableProperty StackProperty = BindableProperty.Create("Stack", typeof(List<ImageWithInfo>), typeof(GridImagesView), new List<ImageWithInfo>(), propertyChanged: OnStackChanged);

        public List<ImageWithInfo> Stack {
            set => SetValue(StackProperty, value);
            get => (List<ImageWithInfo>)GetValue(StackProperty);
        }

        public int BorderSize
        {
            set => SetValue(BorderSizeProperty, value);
            get => (int)GetValue(BorderSizeProperty);
        }

        public int ColumnHeight
        {
            set => SetValue(ColumnHeightProperty, value);
            get => (int)GetValue(ColumnHeightProperty);
        }

        public int CornerRadius
        {
            set => SetValue(CornerRadiusProperty, value);
            get => (int)GetValue(CornerRadiusProperty);
        }

        public double DescriptionFontSize
        {
            get => (double)GetValue(DescriptionFontSizeProperty);
            set => SetValue(DescriptionFontSizeProperty, value);
        }

        public int ImageHeightRequest
        {
            set => SetValue(ImageHeightRequestProperty, value);
            get => (int)GetValue(ImageHeightRequestProperty);
        }

        public double ImagesTitleFontSize
        {
            get => (double)GetValue(ImagesTitleFontSizeProperty);
            set => SetValue(ImagesTitleFontSizeProperty, value);
        }

        public int ImageWidthRequest
        {
            set => SetValue(ImageWidthRequestProperty, value);
            get => (int)GetValue(ImageWidthRequestProperty);
        }

        public ScrollOrientation Orientation
        {
            set => SetValue(OrientationProperty, value);
            get => (ScrollOrientation)GetValue(OrientationProperty);
        }

        public int RowHeight
        {
            set => SetValue(RowHeightProperty, value);
            get => (int)GetValue(RowHeightProperty);
        }

        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set => SetValue(TitleFontSizeProperty, value);
        }

        public bool IsCircle { get; set; } = false;

        public GridImagesView()
        {
            InitializeComponent();
        }

        public static void OnStackChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((GridImagesView)bindable).OnStackChanged((List<ImageWithInfo>)oldValue, (List<ImageWithInfo>)newValue);
        }

        public void OnStackChanged(List<ImageWithInfo> oldValue, List<ImageWithInfo> images)
        {
            if (images != null)
            {
                imagesGrid.Children.Clear();

                switch (Orientation)
                {
                    case ScrollOrientation.Horizontal :
                        ColumnHeight = images.Count / RowHeight;
                        break;
                    case ScrollOrientation.Vertical :
                        RowHeight = images.Count / ColumnHeight;
                        break;
                }

                var index = 0;
                for (var column = 0; column < ColumnHeight; column++)
                {
                    for (var row = 0; row < RowHeight; row++)
                    {
                        if (index >= images.Count)
                            break;

                        images[index].BorderSize = BorderSize;
                        images[index].WidthRequest = ImageWidthRequest;
                        images[index].ImageHeightRequest = ImageHeightRequest;
                        images[index].ImageWidthRequest = ImageWidthRequest;
                        images[index].CornerRadius = IsCircle ? ImageWidthRequest / 2 : CornerRadius;
                        images[index].TitleFontSize = TitleFontSize;
                        images[index].DescriptionFontSize = DescriptionFontSize;
                        images[index].HorizontalOptions = LayoutOptions.CenterAndExpand;

                        imagesGrid.Children.Add(images[index], column, row);
                        index++;
                    }
                }
            }
        }
    }
}
