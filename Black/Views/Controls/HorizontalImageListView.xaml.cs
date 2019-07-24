using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;

using Xamarin.Forms;

namespace Black.Views.Controls
{
    public partial class HorizontalImageListView : ContentView
    {
        public static readonly BindableProperty StackProperty = BindableProperty.Create("Stack", typeof(List<ImageWithInfo>), typeof(HorizontalImageListView), new List<ImageWithInfo>(), propertyChanged: OnStackChanged);

        public List<ImageWithInfo> Stack {
            set => SetValue(StackProperty, value);
            get => (List<ImageWithInfo>)GetValue(StackProperty);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(HorizontalImageListView), string.Empty);

        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create("ImageHeight", typeof(int), typeof(HorizontalImageListView), 180);

        public int ImageHeight
        {
            set => SetValue(ImageHeightProperty, value);
            get => (int)GetValue(ImageHeightProperty);
        }

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create("ImageWidth", typeof(int), typeof(HorizontalImageListView), 120);

        public int ImageWidth
        {
            set => SetValue(ImageWidthProperty, value);
            get => (int)GetValue(ImageWidthProperty);
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(int), typeof(HorizontalImageListView), 6);

        public int CornerRadius
        {
            set => SetValue(CornerRadiusProperty, value);
            get => (int)GetValue(CornerRadiusProperty);
        }

        public HorizontalImageListView()
        {
            InitializeComponent();
        }

        public static void OnStackChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((HorizontalImageListView)bindable).OnStackChanged((List<ImageWithInfo>)oldValue, (List<ImageWithInfo>)newValue);
        }

        public void OnStackChanged(List<ImageWithInfo> oldValue, List<ImageWithInfo> newValue)
        {
            if (newValue != null)
            {
                horizontalStack.Children.Clear();
                foreach (var image in newValue)
                {
                    image.Margin = new Thickness(0, 0, 10, 0);
                    image.BorderSize = 3;
                    image.HeightRequest = ImageHeight;
                    image.WidthRequest = ImageWidth;
                    image.CornerRadius = CornerRadius;

                    horizontalStack.Children.Add(image);
                }
            }
        }
    }
}
