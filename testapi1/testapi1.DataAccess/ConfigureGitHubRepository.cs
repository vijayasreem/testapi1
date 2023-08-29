using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1
{
    public class GitHubRepository : IConfigureGitHubRepository
    {
        private readonly string connectionString;

        public GitHubRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(ConfigureGitHubModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO ConfigureGitHub (GitHubUsername, GitHubPassword, GitHubURL, RepositoryName) VALUES (@GitHubUsername, @GitHubPassword, @GitHubURL, @RepositoryName); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    command.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<ConfigureGitHubModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ConfigureGitHub WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ConfigureGitHubModel
                            {
                                Id = (int)reader["Id"],
                                GitHubUsername = (string)reader["GitHubUsername"],
                                GitHubPassword = (string)reader["GitHubPassword"],
                                GitHubURL = (string)reader["GitHubURL"],
                                RepositoryName = (string)reader["RepositoryName"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<ConfigureGitHubModel>> GetAllAsync()
        {
            List<ConfigureGitHubModel> models = new List<ConfigureGitHubModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ConfigureGitHub", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            models.Add(new ConfigureGitHubModel
                            {
                                Id = (int)reader["Id"],
                                GitHubUsername = (string)reader["GitHubUsername"],
                                GitHubPassword = (string)reader["GitHubPassword"],
                                GitHubURL = (string)reader["GitHubURL"],
                                RepositoryName = (string)reader["RepositoryName"]
                            });
                        }
                    }
                }
            }

            return models;
        }

        public async Task UpdateAsync(ConfigureGitHubModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("UPDATE ConfigureGitHub SET GitHubUsername = @GitHubUsername, GitHubPassword = @GitHubPassword, GitHubURL = @GitHubURL, RepositoryName = @RepositoryName WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    command.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM ConfigureGitHub WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}