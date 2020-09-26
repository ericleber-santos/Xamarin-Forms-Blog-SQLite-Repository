using Simulacao.Data;
using Simulacao.Models;
using Simulacao.Services.Http;
using Simulacao.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Simulacao.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> UsersCollection { get; set; }
        public ICommand ItemSelectionChangedCommand => new Command(async () => await ItemSelectionChanged());

        private User selectedUser;

        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                SetProperty(ref selectedUser, value);
            }
        }

        public UsersViewModel()
        {
            this.UsersCollection = new ObservableCollection<User>();           
        }

        #region métodos
        public async Task UsersDownload()
        {
            var users = await UsersService.DownloadUsersAsync();

            if (users != null && users.Count > 0)
            {
                await userRep.DeleteAllAsync();
                await userRep.InsertAllAsync(users);
            }
        }

        public async Task PostsDownload()
        {
            var posts = await PostsService.DownloadPostsAsync();

            if (posts != null && posts.Count > 0)
            {
                await postRep.DeleteAllAsync();
                await postRep.InsertAllAsync(posts);
            }
        }

        public async Task CommentsDownload()
        {
            var comments = await CommentsService.DownloadCommentsAsync();

            if (comments != null && comments.Count > 0)
            {
                await commentsRep.DeleteAllAsync();
                await commentsRep.InsertAllAsync(comments);
            }
        }

        public async Task DownloadApiData()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await UsersDownload();
                await PostsDownload();
                await CommentsDownload();
            }
        }

        public async Task GetUsers()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                this.UsersCollection.Clear();

                foreach (var user in await userRep.GetAsync())
                {
                    UsersCollection.Add(user);
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

        async Task ItemSelectionChanged()
        {
            if (selectedUser == null)
            {
                return;
            }
            else
            {
                try
                {
                    await Shell.Current.Navigation.PushAsync(new PostsPage(selectedUser), true);
                    selectedUser = null;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public async Task Msg()
        {
            if (UsersCollection.Count < 1)
            {
                await App.Current.MainPage.DisplayAlert("Oops", Resources.AppResources.MsgNoInternet, "Ok");
            }            
        }

        #endregion
    }
}
