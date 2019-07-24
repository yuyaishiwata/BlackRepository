using System;

using Black.Models;

namespace Black.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        Uri authRequestUrl;
        public Uri AuthRequestUrl { get => authRequestUrl; set => SetProperty(ref authRequestUrl, value); }

        public AuthViewModel()
        {
            AuthRequestUrl = new Uri(AuthorizationCodeAuth.GetUrl());
        }
    }
}
