using AutoMapper;
using MotorSocialApp.Application.DTOs;
using MotorSocialApp.Application.Features.Auth.Command.Register;
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
                .ForMember(dest => dest.Followers, opt => opt.Ignore())
                .ForMember(dest => dest.FollowedUsers, opt => opt.Ignore());

            // RegisterCommandRequest -> User
            CreateMap<RegisterCommandRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore()) // UserName'i manuel ayarlıyorsunuz
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore()) // Manuel oluşturulacak
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Hash işlemi için manuel işlem yapılacak
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false)); // Varsayılan olarak false
        }
    }
}
