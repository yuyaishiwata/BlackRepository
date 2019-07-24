using System.Windows.Input;

using Xamarin.Forms;

using Black.Models;

namespace Black.ViewModels
{
    public class UserViewModel : ApplicationViewModel
    {
        User me;
        public User Me { 
            get { return (User)me; }
            set { SetProperty(ref me, value); }
        }


        public Users UsersModel { get; } = new Users();

        public ICommand LoadOrderHistoryCommand { private set; get; }
        public ICommand InsertCommand { private set; get; }

        public ICommand InsertItemsCommand { private set; get; }



        public UserViewModel(INavigation navigation)
        {
            Navigation = navigation;
 
            Me = new User
            {
                Id = 0,
                Name = "ラリサ・マノバン",
                Profile = "早い時期からダンスを始め、ダンスグループの一員であった。2010年にタイで行われたYGエンターテインメントのオーディションでただ1人の合格者。",
                HeaderIcon = "https://kotobank.jp/image/dictionary/nipponica/media/81306024002549.jpg",
                Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/180819_블랙핑크_팬싸인회_코엑스_라이브프라자_리사.jpg/400px-180819_블랙핑크_팬싸인회_코엑스_라이브프라자_리사.jpg",
            };
        }

        public async void InitializeAsync()
        {
        }
    }
}
