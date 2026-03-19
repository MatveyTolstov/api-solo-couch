using SoloCoachApi.ModelDto;

namespace SoloCoachApi.Repositories
{
    public interface IWorkoutCalendarRepository
    {
        Task<WorkoutCalendarDto> GetWorkoutCalendarByIdAsync(int id);
        Task<List<WorkoutCalendarDto>> GetAllWorkoutCalendarsAsync();
        Task<WorkoutCalendarDto> CreateWorkoutCalendarAsync(WorkoutCalendarDto dto);
        Task<WorkoutCalendarDto> UpdateWorkoutCalendarAsync(WorkoutCalendarDto dto);
        Task DeleteWorkoutCalendarAsync(int id);
    }
}

