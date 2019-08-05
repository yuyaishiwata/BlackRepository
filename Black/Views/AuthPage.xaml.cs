using System;
using System.Linq;

using Xamarin.Forms;

using Black.ViewModels;
using Black.Models;

namespace Black.Views
{
    public partial class AuthPage : ContentPage
    {
        AuthViewModel viewModel;

        public AuthPage(bool isClearing = false)
        {
            InitializeComponent();

            if (isClearing)
            {
                Application.Current.Properties.Remove("auth");
                DependencyService.Get<IClearCookies>().Clear();
            }

            BindingContext = viewModel =
                Application.Current.Properties.ContainsKey("auth") ?
                    new AuthViewModel(Navigation, (string)Application.Current.Properties["auth"]) :
                    new AuthViewModel(Navigation);

            viewModel.AuthorizationCompleted += () =>
            {
                Application.Current.Resources["auth"] = viewModel.Auth;
                Application.Current.MainPage = new NavigationPage(new IndexPage());
            };
        }
    }
}
