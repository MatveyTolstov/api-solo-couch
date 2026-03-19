using SoloCoachApi.ModelDto;
using SoloCoachApi.Models;

namespace SoloCoachApi.Mappers
{
    public class WorkoutMapper
    {
        public Workout ToModel(WorkoutDto dto)
        {
            return new Workout
            {
                IdWorkout = dto.IdWorkout,
                Name = dto.Name,
                Description = dto.Description,
                Duration = dto.Duration,
                Complexity = dto.Complexity,
                TypeWorkout = dto.TypeWorkout
            };
        }

        public WorkoutDto ToDto(Workout workout)
        {
            return new WorkoutDto
            {
                IdWorkout = workout.IdWorkout,
                Name = workout.Name,
                Description = workout.Description,
                Duration = workout.Duration,
                Complexity = workout.Complexity,
                TypeWorkout = workout.TypeWorkout
            };
        }
    }
}
