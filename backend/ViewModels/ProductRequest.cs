namespace backend.ViewModels
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}