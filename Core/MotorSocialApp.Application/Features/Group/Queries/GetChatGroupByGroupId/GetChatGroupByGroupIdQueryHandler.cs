using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorSocialApp.Application.DTOs;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetChatGroupByGroupId
{
    public class GetChatGroupByGroupIdQueryHandler : IRequestHandler<GetChatGroupByGroupIdQueryRequest, GetChatGroupByGroupIdQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetChatGroupByGroupIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetChatGroupByGroupIdQueryResponse> Handle(GetChatGroupByGroupIdQueryRequest request, CancellationToken cancellationToken)
        {
            var group = await unitOfWork.GetReadRepository<ChatGroup>()
            .GetAsync(
                predicate: cg => cg.UniqueId == request.UniqueId, // Filtreleme koşulu
                include: query => query.Include(cg => cg.Users) // İlişkili veriyi dahil ediyoruz
            );
            IList<UserChatGroupConnectionUserDto> list = new List<UserChatGroupConnectionUserDto>();

            if (group.Users.Count > 0) {

                foreach (var user in group.Users)
                {
                    user.ChatGroup = null;
                    user.User = await unitOfWork.GetReadRepository<User>().GetAsync(usr => usr.Id == user.UserId);
                    var userDto = new UserChatGroupConnectionUserDto
                    {
                        Id = user.UserId,
                        Bio = user.User.Bio,
                        FullName = user.User.FullName,
                        ProfilePhotoPath = user.User.ProfilePhotoPath
                    };
                    list.Add(userDto);
                }
            }



            var response = new GetChatGroupByGroupIdQueryResponse
            {
                UniqueId=group.UniqueId,
                CurrentMemberCount = group.CurrentMemberCount,
                GroupAdminUserId = group.GroupAdminUserId,
                GroupDescription = group.GroupDescription,
                GroupIconPath = group.GroupIconPath,
                MaxMemberCount = group.MaxMemberCount,
                Name = group.Name,
                Users = list
            };


            return response;
        }
    }
}
