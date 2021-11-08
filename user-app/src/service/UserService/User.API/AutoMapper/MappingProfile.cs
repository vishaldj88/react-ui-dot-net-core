using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;

namespace User.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserDto>()
               .ForMember(dest => dest.id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.first_name, act => act.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.last_name, act => act.MapFrom(src => src.LastName))
               .ForMember(dest => dest.email, act => act.MapFrom(src => src.EmailId))
               .ForMember(dest => dest.gender, act => act.MapFrom(src => src.Gender))
               .ForMember(dest => dest.status, act => act.MapFrom(src => src.Status));
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
               .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.first_name))
               .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.last_name))
               .ForMember(dest => dest.EmailId, act => act.MapFrom(src => src.email))
               .ForMember(dest => dest.Gender, act => act.MapFrom(src => src.gender))
               .ForMember(dest => dest.Status, act => act.MapFrom(src => src.status));
        }
    }
}
