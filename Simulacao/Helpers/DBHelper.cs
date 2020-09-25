using Simulacao.Models;
using Simulacao.Services;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Simulacao.Helpers
{
    public static class DBHelper
    {
        private static SQLiteAsyncConnection _dbConnection;

        /// <summary>
        /// retornar a conexão com o db
        /// </summary>
        public static SQLiteAsyncConnection DBConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SQLiteAsyncConnection(DependencyService.Get<ISQLAndroidPathProvider>().GetDBPath());
                }
                return _dbConnection;
            }
        }

        public static async Task CriateTablesAsync()
        {
            await DBConnection.CreateTablesAsync<User, Post, Comment>();
        }

    }
}
