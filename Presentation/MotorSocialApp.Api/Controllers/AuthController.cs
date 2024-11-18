using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.Auth.Command.Login;
using MotorSocialApp.Application.Features.Auth.Command.RefreshToken;
using MotorSocialApp.Application.Features.Auth.Command.Register;
using MotorSocialApp.Application.Features.Auth.Command.Revoke;
using MotorSocialApp.Application.Features.Auth.Command.RevokeAll;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<AuthController> logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            try
            {
                await mediator.Send(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while registering.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred during registration." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred during login.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred during login." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while refreshing token.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while refreshing token." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            try
            {
                await mediator.Send(request);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while revoking token.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while revoking token." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            try
            {
                await mediator.Send(new RevokeAllCommandRequest());
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while revoking all tokens.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while revoking all tokens." });
            }
        }
    }
}
