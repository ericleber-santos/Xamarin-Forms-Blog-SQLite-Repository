using Simulacao.Helpers;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Simulacao
{
    public partial class App : Application
    {

        public App()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            InitializeComponent();
            Task.FromResult(DBHelper.CriateTablesAsync());
            MainPage = new AppShell();
        }

        protected async override void OnStart()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Oops", "You need to connect to the internet!", "Ok");
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
