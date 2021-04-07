using AutoMapper;
using backend.Models;
using ViewModelShare.Product;

namespace backend.Tests.ProductController
{
    public static class Mapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductRequest, Product>().ReverseMap();
                cfg.CreateMap<ProductRespone, Product>()
                    .AfterMap((pr, p) => pr.CategoryName = p.Category.Name)
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}