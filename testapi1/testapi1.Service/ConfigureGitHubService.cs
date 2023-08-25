HubById", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", configureGitHubModel.Id);
                cmd.Parameters.AddWithValue("@SacralAiUrl", configureGitHubModel.SacralAiUrl);
                cmd.Parameters.AddWithValue("@ExpertServicesPage", configureGitHubModel.ExpertServicesPage);
                cmd.Parameters.AddWithValue("@GitHubUrl", configureGitHubModel.GitHubUrl);
                cmd.Parameters.AddWithValue("@GitHubUsername", configureGitHubModel.GitHubUsername);
                cmd.Parameters.AddWithValue("@GitHubPassword", configureGitHubModel.GitHubPassword);
                cmd.Parameters.AddWithValue("@GitHubRepositoryName", configureGitHubModel.GitHubRepositoryName);
                cmd.Parameters.AddWithValue("@Title", configureGitHubModel.Title);
                cmd.Parameters.AddWithValue("@UserName", configureGitHubModel.UserName);
                cmd.Parameters.AddWithValue("@Action", configureGitHubModel.Action);
                cmd.Parameters.AddWithValue("@EntriesToDisplay", configureGitHubModel.EntriesToDisplay);
                cmd.Parameters.AddWithValue("@PageNumber", configureGitHubModel.PageNumber);

                connection.Open();
                int i = await cmd.ExecuteNonQueryAsync();
                connection.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }

        //Delete ConfigureGitHub
        public async Task<bool> DeleteConfigureGitHub(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete_ConfigureGitHubById", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int i = await cmd.ExecuteNonQueryAsync();
                connection.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }
    }
}

namespace testapi1.Service
{
    public class ConfigureGitHubService
    {
        private readonly IConfigureGitHubRepository _configureGitHubRepository;

        public ConfigureGitHubService(IConfigureGitHubRepository configureGitHubRepository)
        {
            _configureGitHubRepository = configureGitHubRepository;
        }

        public async Task<ConfigureGitHubModel> GetConfigureGitHubById(int id)
        {
            return await _configureGitHubRepository.GetConfigureGitHubById(id);
        }

        public async Task<bool> CreateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            return await _configureGitHubRepository.CreateConfigureGitHub(configureGitHubModel);
        }

        public async Task<bool> UpdateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            return await _configureGitHubRepository.UpdateConfigureGitHub(configureGitHubModel);
        }

        public async Task<bool> DeleteConfigureGitHub(int id)
        {
            return await _configureGitHubRepository.DeleteConfigureGitHub(id);
        }
    }
}