using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebSockets;
using MotorSocialApp.Api.Hubs;
using MotorSocialApp.Application.Features.Post.Command.CreatePost;
using MotorSocialApp.Application.Features.Post.Queries.GetAllPost;
using MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPosts;
using MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPostsByCategoryId;
using MotorSocialApp.Domain.Entities;
using Newtonsoft.Json;

namespace MotorSocialApp.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<ExploreHubService> _hubContext;

        public PostController(IMediator mediator, IHubContext<ExploreHubService> hubContext)
        {
            _mediator = mediator;
            this._hubContext = hubContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(CreatePostCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);

                // SignalR üzerinden istemcilere bildir
                await _hubContext.Clients.All.SendAsync("ReceivePost", new
                {

                });


                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {

            try
            {
                var result = await _mediator.Send(new GetAllPostQueryRequest { });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPaginatedPosts(int page = 1,int pageSize=10)
        {
            var request = new GetPaginatedPostsQueryRequest
            {
                Page = page,PageSize=pageSize

            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPaginatedPostsByCategoryId(int page = 1, int categoryId = 0)
        {
            var request = new GetPaginatedPostsByCategoryIdQueryRequest
            {
                Page = page,
                CategoryId = categoryId
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }


    }
}
