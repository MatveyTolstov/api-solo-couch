using Microsoft.EntityFrameworkCore;
using SoloCoachApi.DataBase;
using SoloCoachApi.Mappers;
using SoloCoachApi.ModelDto;

namespace SoloCoachApi.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationContext _context;
        private readonly WorkoutMapper _workoutMapper;

        public WorkoutRepository(ApplicationContext context, WorkoutMapper workoutMapper)
        {
            _context = context;
            _workoutMapper = workoutMapper;
        }

        public async Task<WorkoutDto> GetWorkoutByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID workout must be a positive number", nameof(id));
            }

            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                throw new KeyNotFoundException($"Workout with ID {id} does not exist");
            }

            return _workoutMapper.ToDto(workout);
        }

        public async Task<List<WorkoutDto>> GetAllWorkoutsAsync()
        {
            var workouts = await _context.Workouts.ToListAsync();
            return workouts.Select(_workoutMapper.ToDto).ToList();
        }

        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto dto)
        {
            var entity = _workoutMapper.ToModel(dto);
            entity.IdWorkout = 0;

            _context.Workouts.Add(entity);
            await _context.SaveChangesAsync();

            return _workoutMapper.ToDto(entity);
        }

        public async Task<WorkoutDto> UpdateWorkoutAsync(WorkoutDto dto)
        {
            if (dto.IdWorkout <= 0)
            {
                throw new ArgumentException("ID workout must be a positive number", nameof(dto.IdWorkout));
            }

            var existing = await _context.Workouts.FindAsync(dto.IdWorkout);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Workout with ID {dto.IdWorkout} does not exist");
            }

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Duration = dto.Duration;
            existing.Complexity = dto.Complexity;
            existing.TypeWorkout = dto.TypeWorkout;

            await _context.SaveChangesAsync();

            return _workoutMapper.ToDto(existing);
        }

        public async Task DeleteWorkoutAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID workout must be a positive number", nameof(id));
            }

            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                throw new KeyNotFoundException($"Workout with ID {id} does not exist");
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }
    }
}

