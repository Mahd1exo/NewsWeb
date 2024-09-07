using System.Collections.Generic;
using NewsWeb.Entittes;

namespace Endpoint.Models
{
    public class HomeViewModel
    {
        public List<News> Trends { get; set; }
        public List<News> LatestNews { get; set; }
        public List<Ads> Ads { get; set; }
        public News HottestNews { get; set; }
       public List<Tag> Tags { get; set; }


    }
}
