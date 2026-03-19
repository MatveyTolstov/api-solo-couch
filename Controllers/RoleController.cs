using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            return Ok(role);
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(RoleDto dto)
        {
            var created = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdRole }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<RoleDto>> Update(int id, RoleDto dto)
        {
            if (id != dto.IdRole)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _roleService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }
    }
}

