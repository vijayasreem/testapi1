public interface IConfigureGitHubService
{
    Task<int> CreateAsync(ConfigureGitHubModel model);
    Task<ConfigureGitHubModel> GetByIdAsync(int id);
    Task<List<ConfigureGitHubModel>> GetAllAsync();
    Task UpdateAsync(ConfigureGitHubModel model);
    Task DeleteAsync(int id);
}