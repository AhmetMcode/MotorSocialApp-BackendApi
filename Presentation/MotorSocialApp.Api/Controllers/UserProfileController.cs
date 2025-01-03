﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorSocialApp.Application.Features.UserProfile.Command.GetProfile;
using MotorSocialApp.Application.Features.UserProfile.Command.UpdateProfile;
using MotorSocialApp.Application.DTOs;
using MotorSocialApp.Application.Features.DeviceTokenAddToUser.Command;
using MotorSocialApp.Application.Features.UserProfile.Command.SearchUserProfile;
using MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerFolder;
using MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerRelationshipFolder;
using MotorSocialApp.Application.Features.UserProfile.Command.UserUnfollowFolder;

namespace MotorSocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(IMediator mediator, ILogger<UserProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(Guid userId)
        {
            try
            {
                var response = await _mediator.Send(new GetUserProfileCommandRequest { UserId = userId });
                return Ok(response); // response artık UserProfileDto türünde olacaktır
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting user profile.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while getting user profile." });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileCommandRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user profile.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddDeviceTokenToUser(DeviceTokenAddToUserCommandRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Follow(UserFollowerFolderCommandRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Unfollow(UserUnfollowFolderCommandRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserFollowerRelationship(UserFollowerRelationshipFolderCommandRequest request)
        {
            try
            {
                var response=await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SearchUserProfile(string searchParameter,Guid searcherUserId)
        {
            try
            {
                var response = await _mediator.Send(new SearchUserProfileCommandRequest
                {
                    SearchParameter = searchParameter,
                    SeracherUserId= searcherUserId
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating user profile." });
            }
        }
    }
}
