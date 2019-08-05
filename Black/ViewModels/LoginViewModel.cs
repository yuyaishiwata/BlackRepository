using System;

using Xamarin.Forms;

using Black.Views;
using Black.Models;

namespace Black.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        Uri authRequestUrl;
        public Uri AuthRequestUrl { get => authRequestUrl; set => SetProperty(ref authRequestUrl, value); }

        public LoginViewModel()
        {
            AuthRequestUrl = new Uri(AuthorizationCodeAuth.GetUrl());
        }
    }
}
