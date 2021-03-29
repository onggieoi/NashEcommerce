using System.ComponentModel;

namespace backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}