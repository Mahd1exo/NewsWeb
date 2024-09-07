using System.Collections.Generic;
using NewsWeb.Entittes;

namespace Endpoint.Models
{
    public class AdminPanelViewModel
    {
        public List<Category> Categories { get; set; }
        public List<News> NewsList { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
