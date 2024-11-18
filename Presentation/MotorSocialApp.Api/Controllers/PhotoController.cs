using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto;
using MotorSocialApp.Application.Features.UserProfile.Query.GetUserPhotos;
using System;
using System.Threading.Tasks;

namespace MotorSocialApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm] UploadPhotoRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPhotos(Guid userId)
        {
            var result = await _mediator.Send(new GetUserPhotosRequest { UserId = userId });
            if (result.IsSuccess)
            {
                return Ok(result.PhotoPaths);
            }
            return BadRequest(result.Message);
        }

    }
}
