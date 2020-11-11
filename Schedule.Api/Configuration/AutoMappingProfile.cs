using AutoMapper;
using Schedule.Api.Dto.Request;
using Schedule.Api.Dto.Response;
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

            CreateMap<Provider, ProviderRequestDto>().ReverseMap();
            CreateMap<Provider, ProviderResponseDto>().ReverseMap();

            CreateMap<ProviderDocument, DocumentRequestDto>().ReverseMap();
            CreateMap<ProviderDocument, DocumentResponseDto>().ReverseMap();
        }
    }
}
