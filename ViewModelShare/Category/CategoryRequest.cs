using Microsoft.AspNetCore.Http;

namespace ViewModelShare.Category
{
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}