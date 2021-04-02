using AutoMapper;
using backend.Models;
using ViewModelShare.Category;

namespace backend.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequest, Category>().ReverseMap();
            CreateMap<CategoryRespone, Category>()
                .ForMember(c => c.Products, p =>
                    p.MapFrom(cr => cr.Products))
                .ReverseMap();
        }
    }
}