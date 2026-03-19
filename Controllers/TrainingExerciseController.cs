using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingExerciseController : ControllerBase
    {
        private readonly TrainingExerciseService _trainingExerciseService;

        public TrainingExerciseController(TrainingExerciseService trainingExerciseService)
        {
            _trainingExerciseService = trainingExerciseService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrainingExerciseDto>> GetById(int id)
        {
            var trainingExercise = await _trainingExerciseService.GetByIdAsync(id);
            return Ok(trainingExercise);
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainingExerciseDto>>> GetAll()
        {
            var trainingExercises = await _trainingExerciseService.GetAllAsync();
            return Ok(trainingExercises);
        }

        [HttpPost]
        public async Task<ActionResult<TrainingExerciseDto>> Create(TrainingExerciseDto dto)
        {
            var created = await _trainingExerciseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdTrainingExercise }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TrainingExerciseDto>> Update(int id, TrainingExerciseDto dto)
        {
            if (id != dto.IdTrainingExercise)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _trainingExerciseService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainingExerciseService.DeleteAsync(id);
            return NoContent();
        }
    }
}

