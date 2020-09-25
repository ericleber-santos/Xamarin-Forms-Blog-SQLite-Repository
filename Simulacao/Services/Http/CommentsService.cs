using Newtonsoft.Json;
using Simulacao.Helpers;
using Simulacao.Models;
using Simulacao.Models.Json;
using Simulacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Simulacao.Services.Http
{
    public static class CommentsService
    {
        public static async Task<List<Comment>> DownloadCommentsAsync()
        {
            List<Comment> _Comments = new List<Comment>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.Timeout = TimeSpan.FromSeconds(20);

                    HttpResponseMessage response = null;
                    try
                    {
                        response = await cliente.GetAsync($"{Constantes.URL_BASE}comments");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var comments = JsonConvert.DeserializeObject<List<CommentsData>>(result);

                        foreach (var comment in comments)
                        {
                            _Comments.Add(new Comment
                            {
                                POST_ID = comment.postId,
                                COMMENT_ID = comment.id,
                                COMMENT_NAME = comment.name,
                                COMMENT_EMAIL = comment.email,
                                COMMENT_BODY = comment.body
                            });
                        }

                        return _Comments;
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
