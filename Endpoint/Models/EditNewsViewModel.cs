using System.Collections.Generic;
using NewsWeb.Entittes;

namespace Endpoint.Models
{
    public class EditNewsViewModel
    {
        public List<Category> Categories { get; set; }
        public News news { get; set; }

    }
}
