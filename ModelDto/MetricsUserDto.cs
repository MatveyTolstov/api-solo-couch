using System.ComponentModel.DataAnnotations;

namespace SoloCoachApi.ModelDto
{
    public class MetricsUserDto
    {
        public int IdMetricsUser { get; set; }

        [Range(50.0, 300.0, ErrorMessage = "Height must be between 50 and 300 cm")]
        public float Height { get; set; }

        [Range(1.0, 500.0, ErrorMessage = "Weight must be between 1 and 500 kg")]
        public float Weight { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150")]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Gender { get; set; }

        [MaxLength(50)]
        public string? ExperienceLevel { get; set; }

        [MaxLength(50)]
        public string? ActivityLevel { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "GoalId must be greater than 0")]
        public int GoalId { get; set; }
    }
}
