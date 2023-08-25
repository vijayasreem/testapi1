GitHubModel configureGitHub = new ConfigureGitHubModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_ConfigureGitHub_ById", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    configureGitHub.Id = Convert.ToInt32(dr["Id"]);
                    configureGitHub.SacralAiUrl = Convert.ToString(dr["SacralAiUrl"]);
                    configureGitHub.ExpertServicesPage = Convert.ToString(dr["ExpertServicesPage"]);
                    configureGitHub.GitHubUrl = Convert.ToString(dr["GitHubUrl"]);
                    configureGitHub.GitHubUsername = Convert.ToString(dr["GitHubUsername"]);
                    configureGitHub.GitHubPassword = Convert.ToString(dr["GitHubPassword"]);
                    configureGitHub.GitHubRepositoryName = Convert.ToString(dr["GitHubRepositoryName"]);
                    configureGitHub.Title = Convert.ToString(dr["Title"]);
                    configureGitHub.UserName = Convert.ToString(dr["UserName"]);
                    configureGitHub.Action = Convert.ToString(dr["Action"]);
                    configureGitHub.EntriesToDisplay = Convert.ToString(dr["EntriesToDisplay"]);
                    configureGitHub.PageNumber = Convert.ToString(dr["PageNumber"]);
                }
                connection.Close();
            }
            return configureGitHub;
        }
    }
}

using System;
using System.Threading.Tasks;
using TestApi1.DTO;

namespace TestApi1.Service
{
    public interface IConfigureGitHubRepository
    {
        Task<bool> CreateConfigureGitHub(ConfigureGitHubModel configureGitHubModel);
        Task<bool> UpdateConfigureGitHub(ConfigureGitHubModel configureGitHubModel);
        Task<ConfigureGitHubModel> GetConfigureGitHubById(int id);
    }
}