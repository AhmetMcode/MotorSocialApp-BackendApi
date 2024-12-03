using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebSockets;

using MotorSocialApp.Application.Features.Post.Command.CreatePost;
using MotorSocialApp.Application.Features.Post.Queries.GetAllPost;
using MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPosts;
using MotorSocialApp.Domain.Entities;
using Newtonsoft.Json;

namespace MotorSocialApp.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
       

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(CreatePostCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
               
               
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPost( )
        {

            try
            {
                var result=await _mediator.Send(new GetAllPostQueryRequest { });
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message); }

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPaginatedPosts(int page = 1)
        {
            var request = new GetPaginatedPostsQueryRequest
            {
                Page = page,
               
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }


    }
}
