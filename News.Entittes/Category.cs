using System.Collections.Generic;

namespace NewsWeb.Entittes
{
    public class Category 
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<News> News { get; set; }


    }
}
