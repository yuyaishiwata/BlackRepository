using Xamarin.Forms;

using Black.ViewModels;

namespace Black.Views
{
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;

        public UserPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel(Navigation);
        }
    }
}
