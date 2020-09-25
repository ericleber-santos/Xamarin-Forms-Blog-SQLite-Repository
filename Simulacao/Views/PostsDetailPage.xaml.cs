using Simulacao.Models;
using Simulacao.ViewModels;
using Xamarin.Forms;

namespace Simulacao.Views
{
    public partial class PostsDetailPage : ContentPage
    {
        readonly PostsDetailViewModel _ViewModel;        
         
        public PostsDetailPage(Post post)
        {
            InitializeComponent();           
            this.BindingContext = _ViewModel = new PostsDetailViewModel(post);                        
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();            
            await _ViewModel.GetComments();
        }
    }
}