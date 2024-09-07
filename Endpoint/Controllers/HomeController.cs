using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Endpoint.Models;
using NewsWeb.Data;
using NewsWeb.EF;
using NewsWeb.Entittes;


namespace Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private NewsRepository newsRepository;
        private AdsRepository adsRepository;
        private CommentRepository commentRepository;
        private CategoryRepository categoryRepository;

        public HomeController(MainContext context)
        {
            newsRepository = new NewsRepository(context);
            adsRepository = new AdsRepository(context);
            commentRepository = new CommentRepository(context);
            categoryRepository = new CategoryRepository(context);
        }
        public IActionResult AdminPanel()
        {
            AdminPanelViewModel model = new AdminPanelViewModel() {
                Categories = categoryRepository.GetCategory(),
                NewsList = newsRepository.AllNews(),
                Comments= commentRepository.GetDeactiveComments()
            };
            
            return View(model);
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                HottestNews = newsRepository.GetHottestNews(),
                LatestNews = newsRepository.GetLastNewsList(),
                Trends = newsRepository.GetTrendList(),
                Ads = adsRepository.GetAds()

            };
            return View(model);
        }

        public IActionResult SingleNews(int id)
        {

            News news = newsRepository.Get(id);
            newsRepository.AddViewCount(id);
            SingleNewsViewModel model = new SingleNewsViewModel()
            {
                Trends = newsRepository.GetTrendList(),
                Ads = adsRepository.GetAds(),
                news = news,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Searching(string search)
        {
            SearchViewModel model = new SearchViewModel()
            {
                Search = newsRepository.Search(search),
                Ads = adsRepository.GetAds(),
                Trends = newsRepository.GetTrendList(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment,int id)
        {
            newsRepository.AddComment(comment, id);
            return RedirectToAction("SingleNews",new { id=id});
        }
        [HttpPost]
        public IActionResult AddNews(News news, string Tags)
        {
            newsRepository.AddNews(news , Tags);
            return RedirectToAction("AdminPanel");
        }
        public IActionResult NewsList(News news)
        {

            var model = newsRepository.AllNews();
            return View(model);
        }
        public IActionResult AddNews()
        {
            var model = categoryRepository.GetCategory();
            return View(model);
        }
        public IActionResult DeleteNews(int id)
        {
            newsRepository.DeleteNews(id);
            return RedirectToAction("AdminPanel");
        }
        
        public IActionResult EditNews(int id)
        {
            EditNewsViewModel model = new EditNewsViewModel() { 
            news= newsRepository.Get(id),
            Categories=categoryRepository.GetCategory()
        };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditNews(News news)
        {
            newsRepository.update(news);
            return RedirectToAction("AdminPanel");
        }
        public IActionResult CommentAdmin()
        {
            return View(commentRepository.GetDeactiveComments());
        }
        public IActionResult CreateNews()
        {
            return View();
        }

        public IActionResult Active(int id)
        {
            commentRepository.ActiveComment(id);
            return RedirectToAction("AdminPanel");
        }
        public IActionResult Delete(int id)
        {
            commentRepository.DeleteComment(id);
            return RedirectToAction("AdminPanel");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
