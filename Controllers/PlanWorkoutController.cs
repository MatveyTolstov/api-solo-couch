using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanWorkoutController : ControllerBase
    {
        private readonly PlanWorkoutService _planWorkoutService;

        public PlanWorkoutController(PlanWorkoutService planWorkoutService)
        {
            _planWorkoutService = planWorkoutService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlanWorkoutDto>> GetById(int id)
        {
            var plan = await _planWorkoutService.GetByIdAsync(id);
            return Ok(plan);
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanWorkoutDto>>> GetAll()
        {
            var plans = await _planWorkoutService.GetAllAsync();
            return Ok(plans);
        }

        [HttpPost]
        public async Task<ActionResult<PlanWorkoutDto>> Create(PlanWorkoutDto dto)
        {
            var created = await _planWorkoutService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdPlanWorkout }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PlanWorkoutDto>> Update(int id, PlanWorkoutDto dto)
        {
            if (id != dto.IdPlanWorkout)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _planWorkoutService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _planWorkoutService.DeleteAsync(id);
            return NoContent();
        }
    }
}

