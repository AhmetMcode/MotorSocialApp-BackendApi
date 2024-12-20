using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Api.Hubs;
using MotorSocialApp.Application.Features.Location.Command.CreateLocation;
using MotorSocialApp.Application.Features.Location.Queries.GetAllLocations;
using MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon;
using MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons;
using MotorSocialApp.Application.Features.UserLastLocationFolder.Command.CreateUserLastLocation;
using MotorSocialApp.Application.Features.UserLastLocationFolder.Queries.GetNearbyUsers;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<LocationHub> hubContext;

        public LocationController(IMediator mediator, IHubContext<LocationHub> hubContext)
        {
            _mediator = mediator;
            this.hubContext = hubContext;
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLocation( CreateLocationCommandRequest request)
        {

            try
            {
                await hubContext.Clients.All.SendAsync("AddLocation",request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUserLastLocation(CreateUserLastLocationCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetNearbyUsers(GetNearbyUsersQueryRequest request)
        {

            try
            {
                var response=await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
