using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Black.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            Application.Current.Resources["browse_page"] = browsePage;
        }
    }
}