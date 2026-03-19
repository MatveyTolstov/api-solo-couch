using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutCalendarController : ControllerBase
    {
        private readonly WorkoutCalendarService _workoutCalendarService;

        public WorkoutCalendarController(WorkoutCalendarService workoutCalendarService)
        {
            _workoutCalendarService = workoutCalendarService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkoutCalendarDto>> GetById(int id)
        {
            var calendar = await _workoutCalendarService.GetByIdAsync(id);
            return Ok(calendar);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutCalendarDto>>> GetAll()
        {
            var calendars = await _workoutCalendarService.GetAllAsync();
            return Ok(calendars);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutCalendarDto>> Create(WorkoutCalendarDto dto)
        {
            var created = await _workoutCalendarService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdWorkoutCalendar }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<WorkoutCalendarDto>> Update(int id, WorkoutCalendarDto dto)
        {
            if (id != dto.IdWorkoutCalendar)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _workoutCalendarService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutCalendarService.DeleteAsync(id);
            return NoContent();
        }
    }
}

