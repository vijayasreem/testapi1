using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi1.DTO;

namespace testapi1
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private string connectionString;

        public UserStoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<List<UserStoryModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM UserStories", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<UserStoryModel> userStories = new List<UserStoryModel>();

                        while (await reader.ReadAsync())
                        {
                            UserStoryModel userStory = new UserStoryModel
                            {
                                Id = reader.GetInt32(0),
                                StoryTitle = reader.GetString(1),
                                Description = reader.GetString(2),
                                AssignedTeamMember = reader.GetString(3)
                            };

                            userStories.Add(userStory);
                        }

                        return userStories;
                    }
                }
            }
        }

        public async Task<UserStoryModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM UserStories WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            UserStoryModel userStory = new UserStoryModel
                            {
                                Id = reader.GetInt32(0),
                                StoryTitle = reader.GetString(1),
                                Description = reader.GetString(2),
                                AssignedTeamMember = reader.GetString(3)
                            };

                            return userStory;
                        }

                        return null;
                    }
                }
            }
        }

        public async Task<int> CreateAsync(UserStoryModel userStory)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO UserStories (StoryTitle, Description, AssignedTeamMember) VALUES (@StoryTitle, @Description, @AssignedTeamMember); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@StoryTitle", userStory.StoryTitle);
                    command.Parameters.AddWithValue("@Description", userStory.Description);
                    command.Parameters.AddWithValue("@AssignedTeamMember", userStory.AssignedTeamMember);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> UpdateAsync(UserStoryModel userStory)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("UPDATE UserStories SET StoryTitle = @StoryTitle, Description = @Description, AssignedTeamMember = @AssignedTeamMember WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", userStory.Id);
                    command.Parameters.AddWithValue("@StoryTitle", userStory.StoryTitle);
                    command.Parameters.AddWithValue("@Description", userStory.Description);
                    command.Parameters.AddWithValue("@AssignedTeamMember", userStory.AssignedTeamMember);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM UserStories WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }
    }
}