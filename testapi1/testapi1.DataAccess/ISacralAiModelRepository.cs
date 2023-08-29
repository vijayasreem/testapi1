
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1.Service
{
    public interface ISacralAiModelRepository
    {
        Task<IEnumerable<SacralAiModel>> GetAllAsync();
        Task<SacralAiModel> GetByIdAsync(int id);
        Task<int> AddAsync(SacralAiModel sacralAiModel);
        Task<bool> UpdateAsync(SacralAiModel sacralAiModel);
        Task<bool> DeleteAsync(int id);
    }
}
