using Newtonsoft.Json;
using Simulacao.Helpers;
using Simulacao.Models;
using Simulacao.Models.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Simulacao.Services.Http
{
    public static class UsersService
    {
        public static async Task<List<User>> DownloadUsersAsync()
        {
            List<User> _Users = new List<User>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = null;
                    try
                    {
                        response = await cliente.GetAsync($"{Constantes.URL_BASE}users");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var users = JsonConvert.DeserializeObject<List<UsersData>>(result);

                        foreach (var user in users)
                        {
                            _Users.Add(new User
                            {
                               USER_ID = user.id,
                               USER_NAME = user.name,
                               USER_EMAIL = user.email,
                               USER_WEBSITE = user.website
                            });
                        }

                        return _Users;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
