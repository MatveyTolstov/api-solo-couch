using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutService _workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkoutDto>> GetById(int id)
        {
            var workout = await _workoutService.GetByIdAsync(id);
            return Ok(workout);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutDto>>> GetAll()
        {
            var workouts = await _workoutService.GetAllAsync();
            return Ok(workouts);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutDto>> Create(WorkoutDto dto)
        {
            var created = await _workoutService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdWorkout }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<WorkoutDto>> Update(int id, WorkoutDto dto)
        {
            if (id != dto.IdWorkout)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _workoutService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutService.DeleteAsync(id);
            return NoContent();
        }
    }
}

