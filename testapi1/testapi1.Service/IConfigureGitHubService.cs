namespace testapi1.DTO
{
    public interface IConfigureGitHubService
    {
        Task<ConfigureGitHubModel> HubById(int id);
        Task<bool> CreateConfigureGitHub(ConfigureGitHubModel configureGitHubModel);
        Task<bool> UpdateConfigureGitHub(ConfigureGitHubModel configureGitHubModel);
        Task<bool> DeleteConfigureGitHub(int id);
    }
}