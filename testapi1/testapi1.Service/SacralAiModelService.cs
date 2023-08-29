using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DataAccess;
using testapi1.DTO;

namespace testapi1.Service
{
    public class SacralAiModelService : ISacralAiModelService
    {
        private readonly ISacralAiModelRepository _repository;

        public SacralAiModelService(ISacralAiModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SacralAiModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SacralAiModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(SacralAiModel sacralAiModel)
        {
            return await _repository.AddAsync(sacralAiModel);
        }

        public async Task<bool> UpdateAsync(SacralAiModel sacralAiModel)
        {
            return await _repository.UpdateAsync(sacralAiModel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}