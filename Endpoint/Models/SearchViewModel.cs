using System.Collections.Generic;
using NewsWeb.Entittes;

namespace Endpoint.Models
{
    public class SearchViewModel
    {
        public List<News> Trends { get; set; }
        public List<News> Search { get; set; }
        public List<Ads> Ads { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
