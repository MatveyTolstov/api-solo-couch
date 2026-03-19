using Microsoft.EntityFrameworkCore;
using SoloCoachApi.DataBase;
using SoloCoachApi.Mappers;
using SoloCoachApi.ModelDto;

namespace SoloCoachApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationContext _context;
        private readonly ExerciseMapper _exerciseMapper;

        public ExerciseRepository(ApplicationContext context, ExerciseMapper exerciseMapper)
        {
            _context = context;
            _exerciseMapper = exerciseMapper;
        }

        public async Task<ExerciseDto> GetExerciseByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID exercise must be a positive number", nameof(id));
            }

            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {id} does not exist");
            }

            return _exerciseMapper.ToDto(exercise);
        }

        public async Task<List<ExerciseDto>> GetAllExercisesAsync()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return exercises.Select(_exerciseMapper.ToDto).ToList();
        }

        public async Task<ExerciseDto> CreateExerciseAsync(ExerciseDto dto)
        {
            var entity = _exerciseMapper.ToModel(dto);
            entity.IdExercise = 0;

            _context.Exercises.Add(entity);
            await _context.SaveChangesAsync();

            return _exerciseMapper.ToDto(entity);
        }

        public async Task<ExerciseDto> UpdateExerciseAsync(ExerciseDto dto)
        {
            if (dto.IdExercise <= 0)
            {
                throw new ArgumentException("ID exercise must be a positive number", nameof(dto.IdExercise));
            }

            var existing = await _context.Exercises.FindAsync(dto.IdExercise);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {dto.IdExercise} does not exist");
            }

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.PictureUrl = dto.PictureUrl;
            existing.Complexity = dto.Complexity;

            await _context.SaveChangesAsync();

            return _exerciseMapper.ToDto(existing);
        }

        public async Task DeleteExerciseAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID exercise must be a positive number", nameof(id));
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {id} does not exist");
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}

