using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using ViewModelShare.CartOrder;
using ViewModelShare.Category;
using ViewModelShare.Product;

namespace backend.Tests
{
    public static class NewDatas
    {
        public static ProductRequest NewProductRequest() => new ProductRequest
        {
            Name = "Test Product Request Name",
            Price = 200,
            Image = "Test Product Request Image",
            Description = "Test Product Request Desc"
        };

        public static Category NewCategory() => new Category
        {
            Name = "Test Category",
            Image = "Test Image"
        };

        public static Product NewProduct() => new Product
        {
            Name = "Test Product Name",
            Price = 100,
            Image = "Test Product Name Image",
            Description = "Test Product Name Desc"
        };

        public static CategoryRequest NewCategoryRequest() => new CategoryRequest
        {
            Name = "Test Category Request",
            Image = "Test Image Request",
            Description = " Test Desc Request"
        };

        public static IdentityUser NewUser() => new IdentityUser
        {
            UserName = "Test User",
        };
    }
}