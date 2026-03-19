using SoloCoachApi.ModelDto;
using SoloCoachApi.Repositories;

namespace SoloCoachApi.Services
{
    public class WorkoutUserLogService
    {
        private readonly IWorkoutUserLogRepository _workoutUserLogRepository;

        public WorkoutUserLogService(IWorkoutUserLogRepository workoutUserLogRepository)
        {
            _workoutUserLogRepository = workoutUserLogRepository;
        }

        public Task<WorkoutUserLogDto> GetByIdAsync(int id) => _workoutUserLogRepository.GetWorkoutUserLogByIdAsync(id);

        public Task<List<WorkoutUserLogDto>> GetAllAsync() => _workoutUserLogRepository.GetAllWorkoutUserLogsAsync();

        public Task<WorkoutUserLogDto> CreateAsync(WorkoutUserLogDto dto) => _workoutUserLogRepository.CreateWorkoutUserLogAsync(dto);

        public Task<WorkoutUserLogDto> UpdateAsync(WorkoutUserLogDto dto) => _workoutUserLogRepository.UpdateWorkoutUserLogAsync(dto);

        public Task DeleteAsync(int id) => _workoutUserLogRepository.DeleteWorkoutUserLogAsync(id);
    }
}

