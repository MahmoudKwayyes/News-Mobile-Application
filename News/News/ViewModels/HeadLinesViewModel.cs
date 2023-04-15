using System;
using System.Collections.Generic;
using System.Text;
using News.Models;
using News.Services;
using System.Web;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
namespace News.ViewModels
{
    class HeadLinesViewModel:ViewModel
    {
        private readonly NewsService newsService;
        public NewsResult CurrentNews { get; set; }

        public HeadLinesViewModel(NewsService newsService)
        {
            this.newsService = newsService;
        }
        public async Task Iinitialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local"=>NewsScope.Local,
                "global"=>NewsScope.Global,
                "Headlines"=>NewsScope.HeadLines,
                _=>NewsScope.HeadLines
            };
            await Initialize(resolvedScope);
        }
        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await newsService.GetNews(scope);
        }
        public ICommand ItemSelected => new Command(async(selectedItem) =>
        {
            var selectedArticle = selectedItem as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
            //Placeholder for more code later on
            await Navigation.NavigateTo($"articleview?url={url}");
        });
    }
}
