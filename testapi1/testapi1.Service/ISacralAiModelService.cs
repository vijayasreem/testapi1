public interface ISacralAiModelService
{
    Task<IEnumerable<SacralAiModel>> GetAllAsync();
    Task<SacralAiModel> GetByIdAsync(int id);
    Task<int> AddAsync(SacralAiModel sacralAiModel);
    Task<bool> UpdateAsync(SacralAiModel sacralAiModel);
    Task<bool> DeleteAsync(int id);
}