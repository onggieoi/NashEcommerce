using System;
using System.Linq;
using AutoMapper;
using backend.Models;
using ViewModelShare.Product;

namespace backend.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<ProductRespone, Product>()
                .AfterMap((pr, p) => pr.CategoryName = p.Category.Name)
                .ReverseMap();
        }
    }
}