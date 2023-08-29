
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testapi1.DTO;
using testapi1.Service;

namespace testapi1.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigureGitHubController : ControllerBase
    {
        private readonly ConfigureGitHubService _service;

        public ConfigureGitHubController(ConfigureGitHubService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ConfigureGitHubModel model)
        {
            try
            {
                var id = await _service.CreateAsync(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var model = await _service.GetByIdAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var models = await _service.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ConfigureGitHubModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors here
                return StatusCode(500, ex.Message);
            }
        }
    }
}
