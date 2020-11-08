using AutoMapper;
using Schedule.Api.Dto.Provider;
using Schedule.Business.Models;

namespace Schedule.Api.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<ProviderPhone, Phone>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Phone.Number))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Phone.Id))
                .ReverseMap();

            CreateMap<Provider, ProviderDto>().ReverseMap();
        }
    }
}
