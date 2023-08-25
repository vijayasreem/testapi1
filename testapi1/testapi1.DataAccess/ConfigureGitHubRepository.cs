GitHubModel configureGitHubModel = new ConfigureGitHubModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_ConfigureGitHubById", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

                while (dataReader.Read())
                {
                    configureGitHubModel.Id = Convert.ToInt32(dataReader["Id"]);
                    configureGitHubModel.SacralAiUrl = Convert.ToString(dataReader["SacralAiUrl"]);
                    configureGitHubModel.ExpertServicesPage = Convert.ToString(dataReader["ExpertServicesPage"]);
                    configureGitHubModel.GitHubUrl = Convert.ToString(dataReader["GitHubUrl"]);
                    configureGitHubModel.GitHubUsername = Convert.ToString(dataReader["GitHubUsername"]);
                    configureGitHubModel.GitHubPassword = Convert.ToString(dataReader["GitHubPassword"]);
                    configureGitHubModel.GitHubRepositoryName = Convert.ToString(dataReader["GitHubRepositoryName"]);
                    configureGitHubModel.Title = Convert.ToString(dataReader["Title"]);
                    configureGitHubModel.UserName = Convert.ToString(dataReader["UserName"]);
                    configureGitHubModel.Action = Convert.ToString(dataReader["Action"]);
                    configureGitHubModel.EntriesToDisplay = Convert.ToInt32(dataReader["EntriesToDisplay"]);
                    configureGitHubModel.PageNumber = Convert.ToInt32(dataReader["PageNumber"]);
                }
                connection.Close();
            }

            return configureGitHubModel;
        }
    }

    public class ConfigureGitHubRepository : IConfigureGitHubRepository
    {
        string connectionString = "Server=localhost;Database=TestApi1;Trusted_Connection=True;";

        //Insert ConfigureGitHub
        public async Task<bool> CreateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_ConfigureGitHub", connection);
                cmd.CommandType = CommandType.StoredProcedure;

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

        //Update ConfigureGitHub
        public async Task<bool> UpdateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update_ConfigureGit