using AutoMapper;
using backend.Models;
using ViewModelShare.CartOrder;

namespace backend.Mappings
{
    public class CartDetailProfile : Profile
    {
        public CartDetailProfile()
        {
            CreateMap<CartOrderRequest, CartDetail>().ReverseMap();
            CreateMap<CartOrderRespone, CartDetail>()
                .ForMember(cartOrderRespone => cartOrderRespone.Product, product =>
                    product.MapFrom(cartDetail => cartDetail.Product))
                .ReverseMap();
        }
    }
}