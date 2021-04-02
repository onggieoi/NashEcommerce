using System.Collections.Generic;
using ViewModelShare.Category;

namespace client.Models
{
    public class HeaderViewModel
    {
        public IEnumerable<CategoryRespone> Categories { get; set; }
        public string UserName { get; set; }
    }
}