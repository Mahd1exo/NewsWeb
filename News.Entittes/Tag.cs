using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Entittes
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<NewsTag> NewsTag { get; set; }
    }
}
