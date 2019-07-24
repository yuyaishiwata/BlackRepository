using Xamarin.Forms;

using Black.ViewModels;

namespace Black.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewmodel { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = viewmodel = new LoginViewModel(Navigation);
        }
    }
}
