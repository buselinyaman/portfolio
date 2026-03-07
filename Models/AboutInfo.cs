using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class AboutInfo
    {
        public int Id { get; set; }

        public string BiographyTR { get; set; } = string.Empty;
        public string BiographyEN { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(500)]
        public string? GithubUrl { get; set; }

        [MaxLength(500)]
        public string? LinkedinUrl { get; set; }

        [MaxLength(500)]
        public string? CvUrl { get; set; }

        public string? ProfileImagePath { get; set; }

        public string FullNameTR { get; set; } = "Ad Soyad";
        public string FullNameEN { get; set; } = "Full Name";

        public string TitleTR { get; set; } = "Yazılım Mühendisliği Öğrencisi";
        public string TitleEN { get; set; } = "Software Engineering Student";
    }
}
