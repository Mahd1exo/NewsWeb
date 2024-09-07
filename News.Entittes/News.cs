using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NewsWeb.Entittes
{

    public class News
    {

        public News()
        {
            PublishDate = DateTime.Now;
            IsHottestNews = false;
            IsPublished = false;
        }
        public int NewsId { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public bool IsHottestNews { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<NewsTag> NewsTag { get; set; }

    }
}
