using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.Location.Command.CreateLocation;
using MotorSocialApp.Application.Features.Location.Queries.GetAllLocations;
using MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon;
using MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }



        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLocation( CreateLocationCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

       // [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var list = await _mediator.Send(new GetAllLocationsQueryRequest());
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
