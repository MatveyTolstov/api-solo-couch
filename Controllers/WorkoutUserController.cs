using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutUserController : ControllerBase
    {
        private readonly WorkoutUserService _workoutUserService;

        public WorkoutUserController(WorkoutUserService workoutUserService)
        {
            _workoutUserService = workoutUserService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkoutUserDto>> GetById(int id)
        {
            var workoutUser = await _workoutUserService.GetByIdAsync(id);
            return Ok(workoutUser);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutUserDto>>> GetAll()
        {
            var workoutUsers = await _workoutUserService.GetAllAsync();
            return Ok(workoutUsers);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutUserDto>> Create(WorkoutUserDto dto)
        {
            var created = await _workoutUserService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdWorkoutUser }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<WorkoutUserDto>> Update(int id, WorkoutUserDto dto)
        {
            if (id != dto.IdWorkoutUser)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _workoutUserService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutUserService.DeleteAsync(id);
            return NoContent();
        }
    }
}

