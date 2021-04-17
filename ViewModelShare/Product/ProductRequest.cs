using Microsoft.AspNetCore.Http;

namespace ViewModelShare.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public int Rated { get; set; }
        public int CategoryId { get; set; }
    }
}