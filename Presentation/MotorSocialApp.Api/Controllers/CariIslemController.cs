using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.CariIslems.Queries.GetAllCariIslems;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CariIslemController : ControllerBase
    {
        private readonly IMediator mediator;

        public CariIslemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllCariIslemsQueryRequest());

            return Ok(response);
        }
    }
}

