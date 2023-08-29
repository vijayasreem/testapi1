
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DTO;
using testapi1.Service;

namespace testapi1.API
{
    [ApiController]
    [Route("api/userstories")]
    public class UserStoryController : ControllerBase
    {
        private readonly UserStoryService userStoryService;

        public UserStoryController(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserStoryModel>>> GetAllUserStoriesAsync()
        {
            try
            {
                var userStories = await userStoryService.GetAllUserStoriesAsync();
                return Ok(userStories);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Failed to get user stories.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStoryModel>> GetUserStoryByIdAsync(int id)
        {
            try
            {
                var userStory = await userStoryService.GetUserStoryByIdAsync(id);

                if (userStory == null)
                {
                    return NotFound();
                }

                return Ok(userStory);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Failed to get user story with ID: {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUserStoryAsync(UserStoryModel userStory)
        {
            try
            {
                var createdUserStoryId = await userStoryService.CreateUserStoryAsync(userStory);
                return Ok(createdUserStoryId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Failed to create user story.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUserStoryAsync(UserStoryModel userStory)
        {
            try
            {
                var isUpdated = await userStoryService.UpdateUserStoryAsync(userStory);

                if (!isUpdated)
                {
                    return NotFound();
                }

                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Failed to update user story with ID: {userStory.Id}.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserStoryAsync(int id)
        {
            try
            {
                var isDeleted = await userStoryService.DeleteUserStoryAsync(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Failed to delete user story with ID: {id}.");
            }
        }
    }
}
