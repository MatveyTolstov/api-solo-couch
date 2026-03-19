using SoloCoachApi.ModelDto;
using SoloCoachApi.Repositories;

namespace SoloCoachApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> GetByIdAsync(int id) => _userRepository.GetUserByIdAsync(id);

        public Task<List<UserDto>> GetAllAsync() => _userRepository.GetAllUsersAsync();

        public Task<UserDto> CreateAsync(UserDto dto) => _userRepository.CreateUserAsync(dto);

        public Task<UserDto> UpdateAsync(UserDto dto) => _userRepository.UpdateUserAsync(dto);

        public Task DeleteAsync(int id) => _userRepository.DeleteUserAsync(id);
    }
}

