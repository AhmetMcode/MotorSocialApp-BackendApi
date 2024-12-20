using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Api.Hubs;
using MotorSocialApp.Application.Features.CallForHelpFolder.Command.SendCallForHelp;
using MotorSocialApp.Application.Features.Group.Command.CreateGroup;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallForHelpController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CallForHelpController> logger;

        public CallForHelpController(IMediator mediator,ILogger<CallForHelpController> logger)
        {
            _mediator = mediator;
            this.logger = logger;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendCallForHelp(SendCallForHelpCommandRequest request)
        {

            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex) {
                logger.LogError(ex.InnerException, ex.ToString());
                return BadRequest(ex.Message); }

        }
    }
}