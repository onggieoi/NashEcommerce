using System.Collections.Generic;
using ViewModelShare.Product;

namespace ViewModelShare.Category
{
    public class CategoryRespone
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual List<ProductRespone> Products { get; set; }
    }
}