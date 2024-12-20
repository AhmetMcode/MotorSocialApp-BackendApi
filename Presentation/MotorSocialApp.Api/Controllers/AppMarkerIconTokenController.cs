using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.AppMarkerIconFolder.Command.CreateAppMarkerIconToken;
using MotorSocialApp.Application.Features.AppMarkerIconFolder.Queries.GetAppMarkerIconTokenByUserId;
using MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon;
using MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppMarkerIconTokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppMarkerIconTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost]
        public async Task<IActionResult> CreateAppMarkerIconToken( CreateAppMarkerIconTokenCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }


        [HttpGet]
        public async Task<IActionResult> GetAppMarkerIconTokenByUserId(Guid userId)
        {
            try
            {
                var list = await _mediator.Send(new GetAppMarkerIconTokenByUserIdQueryRequest
                {
                    UserId= userId
                });
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
