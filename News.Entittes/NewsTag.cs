using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Entittes
{
    public class NewsTag
    {
        public int NewsTagId { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
