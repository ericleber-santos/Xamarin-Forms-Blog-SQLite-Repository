using Simulacao.ViewModels;
using Xamarin.Forms;

namespace Simulacao.Views
{
    public partial class UsersPage : ContentPage
    {
        readonly UsersViewModel _ViewModel;

        public UsersPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new UsersViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();           
            await _ViewModel.UsersDownload();
            await _ViewModel.PostsDownload();
            await _ViewModel.CommentsDownload();           
            await _ViewModel.GetUsers();           
        }
    }
}