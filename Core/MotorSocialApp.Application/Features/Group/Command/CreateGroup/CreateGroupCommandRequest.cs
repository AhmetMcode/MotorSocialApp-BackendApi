using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.CreateGroup
{
    public class CreateGroupCommandRequest : IRequest
    {
       
        public string Name { get; set; } // Grup adı
        public string GroupDescription { get; set; }
        public string GroupIconPath { get; set; }
        public Guid GroupAdminUserId { get; set; }
        public int MaxMemberCount { get; set; }

    }
}
