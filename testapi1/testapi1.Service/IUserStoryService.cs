public interface IUserStoryService
{
    Task<List<UserStoryModel>> GetAllUserStoriesAsync();
    Task<UserStoryModel> GetUserStoryByIdAsync(int id);
    Task<int> CreateUserStoryAsync(UserStoryModel userStory);
    Task<bool> UpdateUserStoryAsync(UserStoryModel userStory);
    Task<bool> DeleteUserStoryAsync(int id);
}