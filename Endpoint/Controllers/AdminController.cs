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
    public class AdminController : Controller
    {
        private NewsRepository newsRepository;
        private AdsRepository adsRepository;
        private CommentRepository commentRepository;
        private CategoryRepository categoryRepository;
        private TagRepository tagRepository;

        public AdminController(MainContext context)
        {
            newsRepository = new NewsRepository(context);
            adsRepository = new AdsRepository(context);
            commentRepository = new CommentRepository(context);
            categoryRepository = new CategoryRepository(context);
            tagRepository = new TagRepository(context);
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
            
            return View();
        }
        public IActionResult News()
        {

            AdminPanelViewModel model = new AdminPanelViewModel()
            {
                Categories = categoryRepository.GetCategory(),
                NewsList = newsRepository.AllNews(),
                Comments = commentRepository.GetDeactiveComments()
            };

            return View(model);
        }
        public IActionResult Category()
        {

            List<Category> model = categoryRepository.GetCategory();

            return View(model);
        }
        public IActionResult Ads()
        {

            List<Ads> model = adsRepository.GetAds();

            return View(model);
        }
        [HttpPost]
        public IActionResult AddAds(Ads ads)
        {

            adsRepository.AddAds(ads);


            return RedirectToAction("Ads");
        }
        public IActionResult DeleteAds(int id)
        {
            adsRepository.DeleteAds(id);
            return RedirectToAction("Ads");
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
        public IActionResult AddNews(News news, string Tags)
        {
            newsRepository.AddNews(news ,Tags);
            
            return RedirectToAction("News");
        }
        [HttpPost]
        public IActionResult AddTag(Tag tag)
        {
            tagRepository.AddTag(tag);
            return RedirectToAction("Tags");
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
            return RedirectToAction("Category");
        }
        public IActionResult DeleteTag(int id)
        {
            tagRepository.RemoveTag(id);
            return RedirectToAction("Tags");
        }

        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.deleteCategory(id);
            return RedirectToAction("Category");
        }

        public IActionResult Tags()
        {
                var model = tagRepository.GetTags();
                return View(model);
        }
        public IActionResult NewsList(News news)
        {

            var model = newsRepository.AllNews();
            return View(model);
        }
        public IActionResult AddNews()
        {
            AdminPanelViewModel model = new AdminPanelViewModel() { 
            Categories=categoryRepository.GetCategory(),
            
            };
            return View(model);
        }
        public IActionResult DeleteNews(string id)
        {
            newsRepository.DeleteNews(int.Parse(id));
            return RedirectToAction("News");
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
            return RedirectToAction("News");
        }
        public IActionResult commentslist()
        {
            return View(commentRepository.GetComments());
        }
        public IActionResult CreateNews()
        {
            return View();
        }

        public IActionResult Active(int id)
        {
            commentRepository.ActiveComment(id);
            return RedirectToAction("Commentslist");
        }
        public IActionResult Delete(int id)
        {
            commentRepository.DeleteComment(id);
            return RedirectToAction("Commentslist");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
