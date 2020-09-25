using Simulacao.Data;
using Simulacao.Models;
using Simulacao.Services.Http;
using Simulacao.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Simulacao.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {
        public ObservableCollection<Post> PostsCollection { get; set; }
        public ICommand ItemSelectionChangedCommand => new Command(async () => await ItemSelectionChanged()); 

        private Post selectedPost;

        public Post SelectedPost
        {
            get
            {
                return selectedPost;
            }
            set
            {
                SetProperty(ref selectedPost, value);                
            }
        }              

        User _User { get; set; }

        public PostsViewModel()
        {
            _User = null;         
            this.PostsCollection = new ObservableCollection<Post>();
            Title = "All Posts";           
        }

        public PostsViewModel(User user)
        {
            this._User = user;
            this.PostsCollection = new ObservableCollection<Post>();
            Title = _User.USER_NAME;           
        }

        #region métodos

        public async Task GetPosts()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.PostsCollection.Clear();
                /*se abrir a partir da UsersPage carrega somente os posts do usuário selecionado, se não, carrega todos*/ 
                var posts = (_User == null ? await postRep.GetAsync() : await postRep.GetAsync<Post>(x => x.POST_USER_ID == _User.USER_ID));
                foreach (var post in  posts)
                {
                    PostsCollection.Add(post);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {                
                IsBusy = false;
                await Task.FromResult(true);
            }
        }

        async Task ItemSelectionChanged()
        {
            if (selectedPost == null)
            {
                return;
            }
            else
            {
                try
                {
                    await Shell.Current.Navigation.PushModalAsync(new PostsDetailPage(selectedPost), true);
                    selectedPost = null;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }  

        #endregion
    }
}
