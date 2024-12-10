using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Api.Hubs;
using MotorSocialApp.Application.Features.Group.Command.CreateGroup;
using MotorSocialApp.Application.Features.Group.Command.JoinGroup;
using MotorSocialApp.Application.Features.Group.Command.SendMessageGroup;
using MotorSocialApp.Application.Features.Group.Queries.GetAllChatGroups;
using MotorSocialApp.Application.Features.Group.Queries.GetGroupMessagesByGroupId;
using MotorSocialApp.Application.Features.Group.Queries.GetUserChatGroups;
using MotorSocialApp.Application.Features.Post.Command.CreatePost;
using MotorSocialApp.Application.Features.Post.Queries.GetAllPost;
using MotorSocialApp.Domain.Entities;
using System.Text.RegularExpressions;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatGroupController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IHubContext<ChatHub> _hubContext;
  

        public ChatGroupController(IMediator mediator, IHubContext<ChatHub> hubContext)
        {
            _mediator = mediator;
            this._hubContext = hubContext;
            _hubContext = hubContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChatGroup(CreateGroupCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);

                //SignalR üzerinden istemcilere bildir
                await _hubContext.Clients.All.SendAsync("ChatGroup", new
                {

                    //Name = request.Name,
                    //GroupIconPath = request.GroupIconPath,
                    //GroupAdminUserId = request.GroupAdminUserId,
                    //GroupDescription = request.GroupDescription,
                });


                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JoinGroup(JoinGroupCommandRequest request)
        {

            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendMessageGroup(SendMessageGroupRequest request)
        {

            try
            {
                await _mediator.Send(request);
                //SignalR üzerinden istemcilere bildir
                await _hubContext.Clients.Groups(request.GroupId.ToString()).SendAsync("ChatMessage", new
                {
                    GroupId = request.GroupId,
                    SenderUserId = request.SenderUserId,
                    SenderUserName = request.SenderUserName,
                    Content = request.Content,
                    SentAt = request.SentAt,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllChatGroups()
        {

            try
            {
                var result = await _mediator.Send(new GetAllChatGroupsQueryRequest());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserChatGroups(Guid userId)
        {

            try
            {
                var result = await _mediator.Send(new GetUserChatGroupsQueryRequest
                {
                    UserId = userId
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetGroupMessagesByGroupId(Guid groupId)
        {

            try
            {
                //await _service.JoinGroup(groupId.ToString());
                var result = await _mediator.Send(new GetGroupMessagesByGroupIdQueryRequest
                {
                    GroupId = groupId
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
