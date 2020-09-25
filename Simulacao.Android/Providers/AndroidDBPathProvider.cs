using Android.OS;
using Simulacao.Droid.Providers;
using Simulacao.Services;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDBPathProvider))]
namespace Simulacao.Droid.Providers
{
    public class AndroidDBPathProvider : ISQLAndroidPathProvider
    {
        public string GetDBPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "simulacao.db3");
        }
    }
}