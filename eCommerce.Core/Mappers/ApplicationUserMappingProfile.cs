using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserId, 
                opt
                    => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Email, 

                opt
                    => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, 

                opt
                    => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Gender, 

                opt
                    => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Token, 

                opt
                    => opt.Ignore()) // If the token is generated separately
            .ForMember(dest => dest.Success,

                opt
                    => opt.Ignore()); // Set default success as required

        CreateMap<RegisterRequest, ApplicationUser>();
    }
}