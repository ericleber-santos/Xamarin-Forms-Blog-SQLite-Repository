using Simulacao.ViewModels;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            await _ViewModel.DownloadApiData();
            await _ViewModel.GetUsers();
            await _ViewModel.Msg();
        }
       
    }
}