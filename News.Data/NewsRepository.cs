using Microsoft.EntityFrameworkCore;
using NewsWeb.EF;
using NewsWeb.Entittes;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NewsWeb.Data
{
    public class NewsRepository
    {
        private readonly MainContext context;
        private TagRepository tagRepository;

        public NewsRepository(MainContext context)
        {
            this.context = context;
            tagRepository = new TagRepository(context);
        }
        public List<News> GetLastNewsList()
        {
            return context.News.Where(a=>!a.IsHottestNews).Where(a=>a.IsPublished).OrderByDescending(a => a.PublishDate).Take(19).ToList();
        }

        public List<News> GetTrendList()
        {
            return context.News.OrderByDescending(a => a.ViewCount).Where(a=>a.IsPublished).Take(8).ToList(); ;
        }

        public News GetHottestNews()
        {
            try
            {
                return context.News.OrderByDescending(a => a.PublishDate).Where(a => a.IsPublished).First(a => a.IsHottestNews);
            }
            catch (Exception)
            {

                return null;
            }

        }

        public void AddComment(Comment comment,int newsId)
        {
            News news = context.News.Include(a=>a.Comments).Single(a => a.NewsId == newsId);
            news.Comments.Add(comment);
            context.SaveChanges();
            
        }

        public News Get(int id)
        {
          
                return context.News.Include(a => a.Comments).Include(a=>a.NewsTag).ThenInclude(pt => pt.Tag)
                        .First(a => a.NewsId == id);

            
        }


        public void AddViewCount(int id)
        {
            News news=context.News.Find(id);
            news.ViewCount += 1;
            context.SaveChanges();
        }
        public List<News> AllNews()
        {
            return context.News.ToList();
        }
        public void AddNews(News news,string Tags)
        {
            context.News.Add(news);
            context.SaveChanges();
            tagRepository.AddTagForNewNews(Tags, news.NewsId);
        }
        public void DeleteNews(int id)
        {
            var cm = context.News.Find(id);
            context.News.Remove(cm);
            context.SaveChanges();
        }


        public  void update(News news)
        {

            context.Update(news);
            context.SaveChanges();
        }

        public List<News> Search(string text)
        {
            List<News> news = context.News.ToList();
            var res = context.News.Include(a=>a.NewsTag).ThenInclude(a=>a.Tag).Where(a => a.Title.Contains(text) || a.Description.Contains(text) || a.Content.Contains(text)).ToList();
            return res;
            /*List<News> res = new List<News>();
          
            for (int i = 0; i < news.Count; i++)
            {
                if (news[i].Title.Contains(text) || news[i].Description.Contains(text) || news[i].Content.Contains(text))
                {
                    res.Add(news[i]);
                }
            

            }
            return res;*/

        }
    }
}
