using Microsoft.AspNetCore.Mvc;
using SoloCoachApi.ModelDto;
using SoloCoachApi.Services;

namespace SoloCoachApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto dto)
        {
            var created = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdUser }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDto>> Update(int id, UserDto dto)
        {
            if (id != dto.IdUser)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var updated = await _userService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}

