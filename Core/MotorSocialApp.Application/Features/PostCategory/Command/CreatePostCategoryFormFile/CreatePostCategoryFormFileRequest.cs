using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.PostCategory.Command.CreatePostCategoryFormFile
{
    public class CreatePostCategoryFormFileRequest : IRequest
    {
        public string CategoryName { get; set; }
        public IFormFile CategoryPhoto { get; set; }
    }
}
