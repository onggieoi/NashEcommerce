using AutoMapper;
using backend.Models;
using ViewModelShare.Rate;

namespace backend.Mappings
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<RateRequest, Rate>().ReverseMap();
        }
    }
}