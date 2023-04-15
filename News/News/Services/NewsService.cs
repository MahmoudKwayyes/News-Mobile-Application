using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using News.Models;
using Newtonsoft.Json;

namespace News.Services
{
    public class NewsService
    {
        public async Task<NewsResult> GetNews(NewsScope Scope)
        {
            string url = GetUrlScope(Scope);

            var webClient = new WebClient();
            var json = await webClient.DownloadStringTaskAsync(url);
            return JsonConvert.DeserializeObject<NewsResult>(json);
        }
        private string GetUrlScope(NewsScope scope)
        {
            return scope switch
            {
                NewsScope.HeadLines =>Headlines,
                NewsScope.Local =>Local,
                NewsScope.Global=>Global,
                _ => throw new Exception("Undefined Scope")
            };
        }
        private string Headlines =>
                                    "https://newsapi.org/v2/top-headlines?" +
                                    "country=us&" +
                                    $"apiKey={Settings.NewsApiKey}";
        private string Local =>
                                     "https://newsapi.org/v2/everything?q=local&" +
                                     $"apiKey={Settings.NewsApiKey}";
        private string Global =>
                                     "https://newsapi.org/v2/everything?q=global&" +
                                     $"apiKey={Settings.NewsApiKey}";
    }
}

