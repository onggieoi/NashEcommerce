using AutoMapper;
using backend.Models;
using ViewModelShare.Category;

namespace backend.Tests.CategoryController
{
    public static class Mapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryRequest, Category>().ReverseMap();
                cfg.CreateMap<CategoryRespone, Category>()
                    .ForMember(c => c.Products, p =>
                        p.MapFrom(cr => cr.Products))
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}