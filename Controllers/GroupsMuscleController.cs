using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsMuscleController : ControllerBase
    {
        private readonly GroupsMuscleService _groupsMuscleService;

        public GroupsMuscleController(GroupsMuscleService groupsMuscleService)
        {
            _groupsMuscleService = groupsMuscleService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GroupsMuscleDto>> GetById(int id)
        {
            var group = await _groupsMuscleService.GetByIdAsync(id);
            return Ok(group);
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupsMuscleDto>>> GetAll()
        {
            var groups = await _groupsMuscleService.GetAllAsync();
            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult<GroupsMuscleDto>> Create(GroupsMuscleDto dto)
        {
            var created = await _groupsMuscleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdGroupsMuscle }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GroupsMuscleDto>> Update(int id, GroupsMuscleDto dto)
        {
            if (id != dto.IdGroupsMuscle)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _groupsMuscleService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupsMuscleService.DeleteAsync(id);
            return NoContent();
        }
    }
}

