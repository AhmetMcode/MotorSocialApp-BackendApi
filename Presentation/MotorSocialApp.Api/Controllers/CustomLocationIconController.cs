using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon;
using MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons;
using MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomLocationIconController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomLocationIconController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost]
        public async Task<IActionResult> AddCustomLocationIcon([FromForm] CreateLocationIconCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }


        [HttpGet]
        public async Task<IActionResult> GetCustomLocationIcons()
        {
            try
            {
                var list = await _mediator.Send(new GetAllCustomLocationIconsQueryRequest());
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
