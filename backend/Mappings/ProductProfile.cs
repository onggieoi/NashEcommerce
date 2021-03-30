using AutoMapper;
using backend.Models;
using backend.ViewModels;

namespace backend.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<ProductRespone, Product>()
                // .ForMember(p => p.Category.Name, opts =>
                //     opts.MapFrom(pr => pr.CategoryName))
                .AfterMap((pr, p) => pr.CategoryName = p.Category.Name)
                .ReverseMap();
        }
    }
}