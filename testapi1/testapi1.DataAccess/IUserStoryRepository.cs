


using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1.Service
{
    public interface IUserStoryRepository
    {
        Task<List<UserStoryModel>> GetAllAsync();
        Task<UserStoryModel> GetByIdAsync(int id);
        Task<int> CreateAsync(UserStoryModel userStory);
        Task<bool> UpdateAsync(UserStoryModel userStory);
        Task<bool> DeleteAsync(int id);
    }
}
