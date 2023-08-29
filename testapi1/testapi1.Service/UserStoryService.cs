using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DataAccess;
using testapi1.DTO;

namespace testapi1.Service
{
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryRepository userStoryRepository;

        public UserStoryService(IUserStoryRepository userStoryRepository)
        {
            this.userStoryRepository = userStoryRepository;
        }

        public async Task<List<UserStoryModel>> GetAllUserStoriesAsync()
        {
            try
            {
                return await userStoryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to get user stories.", ex);
            }
        }

        public async Task<UserStoryModel> GetUserStoryByIdAsync(int id)
        {
            try
            {
                return await userStoryRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to get user story with ID: {id}.", ex);
            }
        }

        public async Task<int> CreateUserStoryAsync(UserStoryModel userStory)
        {
            try
            {
                return await userStoryRepository.CreateAsync(userStory);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to create user story.", ex);
            }
        }

        public async Task<bool> UpdateUserStoryAsync(UserStoryModel userStory)
        {
            try
            {
                return await userStoryRepository.UpdateAsync(userStory);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to update user story with ID: {userStory.Id}.", ex);
            }
        }

        public async Task<bool> DeleteUserStoryAsync(int id)
        {
            try
            {
                return await userStoryRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to delete user story with ID: {id}.", ex);
            }
        }
    }
}