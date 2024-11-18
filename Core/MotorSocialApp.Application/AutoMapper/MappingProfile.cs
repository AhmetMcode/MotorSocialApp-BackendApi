using AutoMapper;
using MotorSocialApp.Application.DTOs;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain Model -> DTO
            CreateMap<User, UserProfileDto>()
                .ForMember(dest => dest.FollowerCount, opt => opt.MapFrom(src => src.Followers.Count))
                .ForMember(dest => dest.FollowingCount, opt => opt.MapFrom(src => src.FollowedUsers.Count));

            // DTO -> Domain Model (Gerekirse)
            CreateMap<UserProfileDto, User>()
                .ForMember(dest => dest.Followers, opt => opt.Ignore()) // Geri dönüşüm sırasında bu alanları manuel ayarlamanız gerekebilir
                .ForMember(dest => dest.FollowedUsers, opt => opt.Ignore());
        }
    }
}
