using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseGroupsMuscleController : ControllerBase
    {
        private readonly ExerciseGroupsMuscleService _exerciseGroupsMuscleService;

        public ExerciseGroupsMuscleController(ExerciseGroupsMuscleService exerciseGroupsMuscleService)
        {
            _exerciseGroupsMuscleService = exerciseGroupsMuscleService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExerciseGroupsMuscleDto>> GetById(int id)
        {
            var entity = await _exerciseGroupsMuscleService.GetByIdAsync(id);
            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseGroupsMuscleDto>>> GetAll()
        {
            var entities = await _exerciseGroupsMuscleService.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseGroupsMuscleDto>> Create(ExerciseGroupsMuscleDto dto)
        {
            var created = await _exerciseGroupsMuscleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdExerciseGroupsMuscle }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ExerciseGroupsMuscleDto>> Update(int id, ExerciseGroupsMuscleDto dto)
        {
            if (id != dto.IdExerciseGroupsMuscle)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _exerciseGroupsMuscleService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseGroupsMuscleService.DeleteAsync(id);
            return NoContent();
        }
    }
}

