using Xamarin.Forms;

using Black.Views;

namespace Black.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command NavigateAuthPage { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;

            NavigateAuthPage = new Command(async () => await Navigation.PushAsync(new AuthPage()));
        }
    }
}
