using Simulacao.Helpers;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Simulacao.Resources;

namespace Simulacao
{
    public partial class App : Application
    {

        public App()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            Task.FromResult(DBHelper.CriateTablesAsync());
            InitializeComponent();            
            MainPage = new AppShell();
        }

        protected async override void OnStart()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Oops", AppResources.MsgNoInternet, "Ok");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
