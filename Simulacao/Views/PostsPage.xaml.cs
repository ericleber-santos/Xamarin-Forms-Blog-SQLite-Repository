using Simulacao.Models;
using Simulacao.ViewModels;
using Xamarin.Forms;

namespace Simulacao.Views
{
    public partial class PostsPage : ContentPage
    {
        readonly PostsViewModel _ViewModel;
        public PostsPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new PostsViewModel();
        }

        public PostsPage(User user)
        {
            InitializeComponent();
            BindingContext = _ViewModel = new PostsViewModel(user);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing(); 
            await _ViewModel.GetPosts();            
        }
    }    
}