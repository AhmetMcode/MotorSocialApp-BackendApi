using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.PostCategory.Command.CreatePostCategoryFormFile;
using MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile;
using MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto;
using MotorSocialApp.Application.Features.UserProfile.Query.GetUserPhotos;

namespace MotorSocialApp.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost]
        public async Task<IActionResult> AddCategoryFormFile([FromForm] CreatePostCategoryFormFileRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }


        [HttpGet]
        public async Task<IActionResult> GetCategoriesFormFile()
        {
            try
            {
                var list = await _mediator.Send(new GetAllPostCategoryFormFileRequest());
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
