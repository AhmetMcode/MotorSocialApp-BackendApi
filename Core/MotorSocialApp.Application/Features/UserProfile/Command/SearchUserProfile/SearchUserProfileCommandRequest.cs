using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.SearchUserProfile
{
    public class SearchUserProfileCommandRequest :IRequest<IList<SearchUserProfileCommandResponse>>
    {
        public string? SearchParameter{ get; set; }
        public Guid SeracherUserId { get; set; }
    }
}
