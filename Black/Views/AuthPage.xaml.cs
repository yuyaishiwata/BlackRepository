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

        public AuthPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AuthViewModel();

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
                    Application.Current.Resources.Add("auth", auth);

                    var mainPage = new MainPage();
                    NavigationPage.SetHasNavigationBar(mainPage, false);

                    Application.Current.MainPage = new NavigationPage(mainPage);
                }
            }
        }
    }
}
