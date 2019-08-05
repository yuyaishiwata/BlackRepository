using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using Black.Models;
using Black.Views;

namespace Black.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        public delegate void AuthorizationCompletedHandler();
        public event AuthorizationCompletedHandler AuthorizationCompleted;

        public Command NavigateLoginPage { get; private set; }

        public AuthorizationCodeAuth Auth { get; private set; }

        bool isInitialized;
        public bool IsInitialized { get => isInitialized; private set => SetProperty(ref isInitialized, value); }

        public AuthViewModel(INavigation navigation, string refreshToken = "")
        {
            Navigation = navigation;
            NavigateLoginPage = new Command(async () => await Navigation.PushAsync(new LoginPage()));

            if (string.IsNullOrEmpty(refreshToken))
                IsInitialized = true;
            else
                _ = InitializeAsync(refreshToken);
        }

        public async Task InitializeAsync(string refreshToken)
        {
            IsRunning = true;

            Auth = await AuthorizationCodeAuth.GetTokenByRefreshToken(refreshToken);

            if (Auth != null)
            {
                var completed = AuthorizationCompleted;
                if (completed != null)
                {
                    completed.Invoke();
                }
            }

            IsInitialized = true;
            IsRunning = false;
        }
    }
}
