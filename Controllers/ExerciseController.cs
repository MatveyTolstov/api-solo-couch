using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExerciseDto>> GetById(int id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);
            return Ok(exercise);
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseDto>>> GetAll()
        {
            var exercises = await _exerciseService.GetAllAsync();
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDto>> Create(ExerciseDto dto)
        {
            var created = await _exerciseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdExercise }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ExerciseDto>> Update(int id, ExerciseDto dto)
        {
            if (id != dto.IdExercise)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _exerciseService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseService.DeleteAsync(id);
            return NoContent();
        }
    }
}

