using System.Collections.Generic;
using NewsWeb.Entittes;

namespace Endpoint.Models
{
    public class SingleNewsViewModel
    {
        public List<Ads> Ads { get; set; }
        public List<News> Trends { get; set; }
        public News news { get; set; }

    }
}
