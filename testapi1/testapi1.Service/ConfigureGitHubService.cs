using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi1.DataAccess;
using testapi1.DTO;

namespace testapi1.Service
{
    public class ConfigureGitHubService : IConfigureGitHubService
    {
        private readonly IConfigureGitHubRepository _repository;

        public ConfigureGitHubService(IConfigureGitHubRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(ConfigureGitHubModel model)
        {
            try
            {
                // Perform any necessary validation or business logic here
                
                return await _repository.CreateAsync(model);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                throw;
            }
        }

        public async Task<ConfigureGitHubModel> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                throw;
            }
        }

        public async Task<List<ConfigureGitHubModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                throw;
            }
        }

        public async Task UpdateAsync(ConfigureGitHubModel model)
        {
            try
            {
                // Perform any necessary validation or business logic here
                
                await _repository.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                throw;
            }
        }
    }
}