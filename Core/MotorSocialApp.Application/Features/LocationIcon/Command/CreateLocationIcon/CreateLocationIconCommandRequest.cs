using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon
{
    public class CreateLocationIconCommandRequest : IRequest
    {
        public string CategoryName { get; set; }
        public IFormFile CategoryPhoto { get; set; }
        public int Price { get; set; }
    }
}
