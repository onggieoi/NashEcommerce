using AutoMapper;
using backend.Models;
using ViewModelShare.CartOrder;
using ViewModelShare.Product;

namespace backend.Tests.OrderController
{
    public static class Mapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartOrderRequest, CartDetail>().ReverseMap();
                cfg.CreateMap<CartOrderRespone, CartDetail>()
                    .ForMember(cartOrderRespone => cartOrderRespone.Product, product =>
                        product.MapFrom(cartDetail => cartDetail.Product))
                    .ReverseMap();

                cfg.CreateMap<ProductRequest, Product>().ReverseMap();
                cfg.CreateMap<ProductRespone, Product>()
                    .AfterMap((pr, p) => pr.CategoryName = p.Category.Name)
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}