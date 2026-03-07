using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class SocialEvent
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string TitleTR { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string TitleEN { get; set; } = string.Empty;

        [Required]
        public string DescriptionTR { get; set; } = string.Empty;

        [Required]
        public string DescriptionEN { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        [MaxLength(100)]
        public string EventTypeTR { get; set; } = string.Empty;

        [MaxLength(100)]
        public string EventTypeEN { get; set; } = string.Empty;

        public DateOnly EventDate { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }

        public int OrderIndex { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
