using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly GoalService _goalService;

        public GoalController(GoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GoalDto>> GetById(int id)
        {
            var goal = await _goalService.GetByIdAsync(id);
            return Ok(goal);
        }

        [HttpGet]
        public async Task<ActionResult<List<GoalDto>>> GetAll()
        {
            var goals = await _goalService.GetAllAsync();
            return Ok(goals);
        }

        [HttpPost]
        public async Task<ActionResult<GoalDto>> Create(GoalDto dto)
        {
            var created = await _goalService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdGoal }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GoalDto>> Update(int id, GoalDto dto)
        {
            if (id != dto.IdGoal)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _goalService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _goalService.DeleteAsync(id);
            return NoContent();
        }
    }
}

