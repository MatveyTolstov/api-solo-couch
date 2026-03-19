using SoloCoachApi.ModelDto;
using SoloCoachApi.Repositories;

namespace SoloCoachApi.Services
{
    public class WorkoutCalendarService
    {
        private readonly IWorkoutCalendarRepository _workoutCalendarRepository;

        public WorkoutCalendarService(IWorkoutCalendarRepository workoutCalendarRepository)
        {
            _workoutCalendarRepository = workoutCalendarRepository;
        }

        public Task<WorkoutCalendarDto> GetByIdAsync(int id) => _workoutCalendarRepository.GetWorkoutCalendarByIdAsync(id);

        public Task<List<WorkoutCalendarDto>> GetAllAsync() => _workoutCalendarRepository.GetAllWorkoutCalendarsAsync();

        public Task<WorkoutCalendarDto> CreateAsync(WorkoutCalendarDto dto) => _workoutCalendarRepository.CreateWorkoutCalendarAsync(dto);

        public Task<WorkoutCalendarDto> UpdateAsync(WorkoutCalendarDto dto) => _workoutCalendarRepository.UpdateWorkoutCalendarAsync(dto);

        public Task DeleteAsync(int id) => _workoutCalendarRepository.DeleteWorkoutCalendarAsync(id);
    }
}

