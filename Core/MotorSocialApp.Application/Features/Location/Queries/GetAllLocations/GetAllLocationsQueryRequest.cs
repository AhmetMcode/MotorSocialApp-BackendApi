﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Location.Queries.GetAllLocations
{
    public class GetAllLocationsQueryRequest  : IRequest<IList<GetAllLocationsQueryResponse>>
    {
    }
}