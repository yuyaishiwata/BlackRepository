using System;
using System.Linq;
using Xamarin.Forms;

using Black.Models;
using Black.ViewModels;

namespace Black.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();

            web.Navigating += OnNavigating;
        }

        private async void OnNavigating(object sender, WebNavigatingEventArgs args)
        {
            if (args.Url.StartsWith("black://localhost/auth/spotify", StringComparison.CurrentCulture))
            {
                web.Navigating -= OnNavigating;

                var uri = new Uri(args.Url);
                if (uri.Query.StartsWith("?code=", StringComparison.CurrentCulture))
                {
                    string code = uri.Query.TrimStart('?').Split('&').First().Split('=').LastOrDefault();

                    AuthorizationCodeAuth auth = await AuthorizationCodeAuth.GetToken(code);
                    Application.Current.Resources["auth"] = auth;
                    Application.Current.Properties["auth"] = auth.RefreshToken;
                    await Application.Current.SavePropertiesAsync();

                    Application.Current.MainPage = new NavigationPage(new IndexPage());
                }
            }
        }
    }
}
