using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsUserController : ControllerBase
    {
        private readonly MetricsUserService _metricsUserService;

        public MetricsUserController(MetricsUserService metricsUserService)
        {
            _metricsUserService = metricsUserService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MetricsUserDto>> GetById(int id)
        {
            var metrics = await _metricsUserService.GetByIdAsync(id);
            return Ok(metrics);
        }

        [HttpGet]
        public async Task<ActionResult<List<MetricsUserDto>>> GetAll()
        {
            var metrics = await _metricsUserService.GetAllAsync();
            return Ok(metrics);
        }

        [HttpPost]
        public async Task<ActionResult<MetricsUserDto>> Create(MetricsUserDto dto)
        {
            var created = await _metricsUserService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdMetricsUser }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MetricsUserDto>> Update(int id, MetricsUserDto dto)
        {
            if (id != dto.IdMetricsUser)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _metricsUserService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _metricsUserService.DeleteAsync(id);
            return NoContent();
        }
    }
}

