using backend.Models;
using Microsoft.Extensions.Logging;
using Moq;
using ViewModelShare.Product;

namespace backend.Tests
{
    public static class NewDatas
    {
        public static ProductRequest NewProductRequest() => new ProductRequest
        {
            Name = "Test",
            Price = 100,
            Image = "IMAGE",
            Description = "Description"
        };

        public static Category NewCategory() => new Category
        {
            Name = "Test Category 1",
            Image = "IMAGE"
        };
    }
}