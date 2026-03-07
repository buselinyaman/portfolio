using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        public int Proficiency { get; set; } = 80;

        public int OrderIndex { get; set; } = 0;
    }
}
