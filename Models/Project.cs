using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Project
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

        [MaxLength(500)]
        public string? GithubUrl { get; set; }

        [MaxLength(500)]
        public string? LiveUrl { get; set; }

        public string TechStack { get; set; } = string.Empty;

        public bool IsFeatured { get; set; } = false;

        public int OrderIndex { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    //public class SocialEvent
    //{
    //    public int Id { get; set; }

    //    [Required, MaxLength(200)]
    //    public string TitleTR { get; set; } = string.Empty;

    //    [Required, MaxLength(200)]
    //    public string TitleEN { get; set; } = string.Empty;

    //    [Required]
    //    public string DescriptionTR { get; set; } = string.Empty;

    //    [Required]
    //    public string DescriptionEN { get; set; } = string.Empty;

    //    public string? ImagePath { get; set; }

    //    [MaxLength(100)]
    //    public string EventTypeTR { get; set; } = string.Empty;

    //    [MaxLength(100)]
    //    public string EventTypeEN { get; set; } = string.Empty; 

    //    public DateOnly EventDate { get; set; }

    //    [MaxLength(200)]
    //    public string? Location { get; set; }

    //    public int OrderIndex { get; set; } = 0;

    //    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    //    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    //}

    //public class Skill
    //{
    //    public int Id { get; set; }

    //    [Required, MaxLength(100)]
    //    public string Name { get; set; } = string.Empty;

    //    [MaxLength(50)]
    //    public string Category { get; set; } = string.Empty;

    //    public int Proficiency { get; set; } = 80;

    //    public int OrderIndex { get; set; } = 0;
    //}

    //public class AboutInfo
    //{
    //    public int Id { get; set; }

    //    public string BiographyTR { get; set; } = string.Empty;
    //    public string BiographyEN { get; set; } = string.Empty;

    //    [MaxLength(200)]
    //    public string Email { get; set; } = string.Empty;

    //    [MaxLength(200)]
    //    public string? Phone { get; set; }

    //    [MaxLength(200)]
    //    public string? Location { get; set; }

    //    [MaxLength(500)]
    //    public string? GithubUrl { get; set; }

    //    [MaxLength(500)]
    //    public string? LinkedinUrl { get; set; }

    //    [MaxLength(500)]
    //    public string? CvUrl { get; set; }

    //    public string? ProfileImagePath { get; set; }

    //    public string FullNameTR { get; set; } = "Ad Soyad";
    //    public string FullNameEN { get; set; } = "Full Name";

    //    public string TitleTR { get; set; } = "Yazılım Mühendisliği Öğrencisi";
    //    public string TitleEN { get; set; } = "Software Engineering Student";
    //}
}
