using Simulacao.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Simulacao.ViewModels
{
    public class PostsDetailViewModel : BaseViewModel
    {
        public Post _Post { get; set; }
        public ICommand AddCommentCommand => new Command(async () => await AddComment());
        public ObservableCollection<Comment> CommentsCollection { get; set; }
         
        public PostsDetailViewModel(Post post)
        {
            this._Post = post;
            this.CommentsCollection = new ObservableCollection<Comment>();            
        }

        #region métodos      

        public async Task GetComments()
        {
            if (IsBusy || _Post == null)
                return;

            IsBusy = true;

            try
            {
                this.CommentsCollection.Clear();

                var coments = await commentsRep.GetAsync();

                foreach (var comment in coments.Where(x=> x.POST_ID == _Post.POST_ID))
                {
                    CommentsCollection.Add(comment);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;                
            }
        }

        private async Task AddComment()
        {
            await App.Current.MainPage.DisplayAlert("Oops", "Not implemented yet, man working!","Ok");
        }

        #endregion
    }
}
