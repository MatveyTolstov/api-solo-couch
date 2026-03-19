using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutUserLogController : ControllerBase
    {
        private readonly WorkoutUserLogService _workoutUserLogService;

        public WorkoutUserLogController(WorkoutUserLogService workoutUserLogService)
        {
            _workoutUserLogService = workoutUserLogService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkoutUserLogDto>> GetById(int id)
        {
            var log = await _workoutUserLogService.GetByIdAsync(id);
            return Ok(log);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutUserLogDto>>> GetAll()
        {
            var logs = await _workoutUserLogService.GetAllAsync();
            return Ok(logs);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutUserLogDto>> Create(WorkoutUserLogDto dto)
        {
            var created = await _workoutUserLogService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdWorkoutUserLog }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<WorkoutUserLogDto>> Update(int id, WorkoutUserLogDto dto)
        {
            if (id != dto.IdWorkoutUserLog)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _workoutUserLogService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutUserLogService.DeleteAsync(id);
            return NoContent();
        }
    }
}

