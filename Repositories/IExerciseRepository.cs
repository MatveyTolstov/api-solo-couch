using SoloCoachApi.ModelDto;

namespace SoloCoachApi.Repositories
{
    public interface IExerciseRepository
    {
        Task<ExerciseDto> GetExerciseByIdAsync(int id);
        Task<List<ExerciseDto>> GetAllExercisesAsync();
        Task<ExerciseDto> CreateExerciseAsync(ExerciseDto dto);
        Task<ExerciseDto> UpdateExerciseAsync(ExerciseDto dto);
        Task DeleteExerciseAsync(int id);
    }
}

