using System.ComponentModel.DataAnnotations;

namespace SoloCoachApi.ModelDto
{
    public class WorkoutCalendarDto
    {
        public int IdWorkoutCalendar { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than 0")]
        public int UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "WorkoutId must be greater than 0")]
        public int WorkoutId { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
