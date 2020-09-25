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
    public static class PostsService
    {
        public static async Task<List<Post>> DownloadPostsAsync()
        {
            List<Post> _Posts = new List<Post>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromSeconds(20);                    

                    HttpResponseMessage response = null;
                    try
                    {
                        response = await cliente.GetAsync($"{Constantes.URL_BASE}posts");                        
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var posts = JsonConvert.DeserializeObject<List<PostsData>>(result);

                        foreach (var post in posts)
                        {
                            _Posts.Add(new Post
                            {
                                POST_USER_ID = post.userId,
                                POST_ID = post.id,
                                POST_TITLE = post.title,
                                POST_BODY = post.body
                            });
                        }

                        return _Posts;
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
