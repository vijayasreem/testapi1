using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1
{
    public class SacralAiModelRepository : ISacralAiModelRepository
    {
        private readonly string connectionString;

        public SacralAiModelRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<SacralAiModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM SacralAiModel", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<SacralAiModel> sacralAiModels = new List<SacralAiModel>();

                        while (await reader.ReadAsync())
                        {
                            SacralAiModel sacralAiModel = new SacralAiModel
                            {
                                Id = (int)reader["Id"],
                                GitHubUsername = (string)reader["GitHubUsername"],
                                GitHubPassword = (string)reader["GitHubPassword"],
                                GitHubUrl = (string)reader["GitHubUrl"],
                                RepositoryName = (string)reader["RepositoryName"]
                            };

                            sacralAiModels.Add(sacralAiModel);
                        }

                        return sacralAiModels;
                    }
                }
            }
        }

        public async Task<SacralAiModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM SacralAiModel WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            SacralAiModel sacralAiModel = new SacralAiModel
                            {
                                Id = (int)reader["Id"],
                                GitHubUsername = (string)reader["GitHubUsername"],
                                GitHubPassword = (string)reader["GitHubPassword"],
                                GitHubUrl = (string)reader["GitHubUrl"],
                                RepositoryName = (string)reader["RepositoryName"]
                            };

                            return sacralAiModel;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public async Task<int> AddAsync(SacralAiModel sacralAiModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO SacralAiModel (GitHubUsername, GitHubPassword, GitHubUrl, RepositoryName) VALUES (@GitHubUsername, @GitHubPassword, @GitHubUrl, @RepositoryName); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@GitHubUsername", sacralAiModel.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", sacralAiModel.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubUrl", sacralAiModel.GitHubUrl);
                    command.Parameters.AddWithValue("@RepositoryName", sacralAiModel.RepositoryName);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> UpdateAsync(SacralAiModel sacralAiModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("UPDATE SacralAiModel SET GitHubUsername = @GitHubUsername, GitHubPassword = @GitHubPassword, GitHubUrl = @GitHubUrl, RepositoryName = @RepositoryName WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", sacralAiModel.Id);
                    command.Parameters.AddWithValue("@GitHubUsername", sacralAiModel.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", sacralAiModel.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubUrl", sacralAiModel.GitHubUrl);
                    command.Parameters.AddWithValue("@RepositoryName", sacralAiModel.RepositoryName);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM SacralAiModel WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
    }
}