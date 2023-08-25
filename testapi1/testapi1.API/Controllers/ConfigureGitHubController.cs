namespace testapi1.DTO
{
    public class ConfigureGitHubModel
    {
        public int Id { get; set; }
        public string SacralAiUrl { get; set; }
        public string ExpertServicesPage { get; set; }
        public string GitHubUrl { get; set; }
        public string GitHubUsername { get; set; }
        public string GitHubPassword { get; set; }
        public string GitHubRepositoryName { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public int EntriesToDisplay { get; set; }
        public int PageNumber { get; set; }
    }
}

using testapi1.API.Controllers;
using testapi1.DTO;
using testapi1.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace testapi1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureGitHubController : ControllerBase
    {
        private readonly ConfigureGitHubService _configureGitHubService;

        public ConfigureGitHubController(ConfigureGitHubService configureGitHubService)
        {
            _configureGitHubService = configureGitHubService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigureGitHubModel>> GetConfigureGitHubById(int id)
        {
            var configureGitHubModel = await _configureGitHubService.GetConfigureGitHubById(id);
            if (configureGitHubModel == null)
            {
                return NotFound();
            }

            return configureGitHubModel;
        }

        [HttpPost]
        public async Task<ActionResult<ConfigureGitHubModel>> CreateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            await _configureGitHubService.CreateConfigureGitHub(configureGitHubModel);

            return CreatedAtAction(nameof(GetConfigureGitHubById), new { id = configureGitHubModel.Id }, configureGitHubModel);
        }

        [HttpPut]
        public async Task<ActionResult<ConfigureGitHubModel>> UpdateConfigureGitHub(ConfigureGitHubModel configureGitHubModel)
        {
            await _configureGitHubService.UpdateConfigureGitHub(configureGitHubModel);

            return CreatedAtAction(nameof(GetConfigureGitHubById), new { id = configureGitHubModel.Id }, configureGitHubModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConfigureGitHub(int id)
        {
            await _configureGitHubService.DeleteConfigureGitHub(id);
            return NoContent();
        }
    }
}