using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.SearchUserProfile
{
    internal class SearchUserProfileCommandHandler : IRequestHandler<SearchUserProfileCommandRequest, IList<SearchUserProfileCommandResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public SearchUserProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<SearchUserProfileCommandResponse>> Handle(SearchUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var userList = await unitOfWork.GetReadRepository<User>().GetAllAsync(usr=>usr.FullName.Contains(request.SearchParameter));
            List<SearchUserProfileCommandResponse> responses = new List<SearchUserProfileCommandResponse> ();

            foreach (var user in userList) {
                if (user.Id != request.SeracherUserId) {
                    var response = new SearchUserProfileCommandResponse
                    {
                        FullName = user.FullName,
                        Id = user.Id,
                        ProfilePhotoPath = user.ProfilePhotoPath
                    };
                    responses.Add(response);
                }
            }

            return responses;
        
        }
    }
}
