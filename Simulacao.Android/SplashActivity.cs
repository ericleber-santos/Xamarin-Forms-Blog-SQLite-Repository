using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace Simulacao.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    { 
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);           
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();           
            SimulateStartup();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        void SimulateStartup()
        {        
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }
    }
}