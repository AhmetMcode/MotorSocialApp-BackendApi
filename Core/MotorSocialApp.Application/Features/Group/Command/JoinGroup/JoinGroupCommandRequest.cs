﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.JoinGroup
{
    public class JoinGroupCommandRequest : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
