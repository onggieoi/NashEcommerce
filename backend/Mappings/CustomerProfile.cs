using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ViewModelShare.Customer;

namespace backend.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerResponse, IdentityUser>().ReverseMap();
        }
    }
}