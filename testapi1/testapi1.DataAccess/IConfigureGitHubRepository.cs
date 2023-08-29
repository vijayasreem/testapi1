
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1.Service
{
    public interface IConfigureGitHubRepository
    {
        Task<int> CreateAsync(ConfigureGitHubModel model);
        Task<ConfigureGitHubModel> GetByIdAsync(int id);
        Task<List<ConfigureGitHubModel>> GetAllAsync();
        Task UpdateAsync(ConfigureGitHubModel model);
        Task DeleteAsync(int id);
    }
}
