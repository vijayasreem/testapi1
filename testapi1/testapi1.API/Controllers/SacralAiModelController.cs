
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
    public class SacralAiModelController : ControllerBase
    {
        private readonly SacralAiModelService _service;

        public SacralAiModelController(SacralAiModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SacralAiModel>>> GetAllAsync()
        {
            try
            {
                var sacralAiModels = await _service.GetAllAsync();
                return Ok(sacralAiModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SacralAiModel>> GetByIdAsync(int id)
        {
            try
            {
                var sacralAiModel = await _service.GetByIdAsync(id);
                if (sacralAiModel == null)
                {
                    return NotFound();
                }
                return Ok(sacralAiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync(SacralAiModel sacralAiModel)
        {
            try
            {
                var id = await _service.AddAsync(sacralAiModel);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAsync(SacralAiModel sacralAiModel)
        {
            try
            {
                var success = await _service.UpdateAsync(sacralAiModel);
                if (!success)
                {
                    return NotFound();
                }
                return Ok(success);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            try
            {
                var success = await _service.DeleteAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return Ok(success);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
