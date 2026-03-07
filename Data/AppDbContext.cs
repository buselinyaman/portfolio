using Microsoft.EntityFrameworkCore;
using PortfolioSite.Models;

namespace PortfolioSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<SocialEvent> SocialEvents { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AboutInfo> AboutInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (!db.AboutInfos.Any())
            {
                db.AboutInfos.Add(new AboutInfo
                {
                    FullNameTR = "Adın Soyadın",
                    FullNameEN = "Your Full Name",
                    TitleTR = "Yazılım Mühendisliği Öğrencisi",
                    TitleEN = "Software Engineering Student",
                    BiographyTR = "Merhaba! Ben 3. sınıf Yazılım Mühendisliği öğrencisiyim. Yeni teknolojiler öğrenmekten, projeler geliştirmekten ve topluluk etkinliklerine katılmaktan büyük keyif alıyorum.",
                    BiographyEN = "Hello! I'm a 3rd year Software Engineering student. I love learning new technologies, building projects, and participating in community events.",
                    Email = "email@example.com",
                    GithubUrl = "https://github.com/buselinyaman",
                    LinkedinUrl = "https://www.linkedin.com/in/buse-selin-yaman/",
                    Location = "Sakarya,Türkiye"
                });
            }

            if (!db.Skills.Any())
            {
                var skills = new List<Skill>
                {
                    new() { Name = "C#", Category = "Backend", Proficiency = 85, OrderIndex = 1 },
                    new() { Name = "ASP.NET Core", Category = "Backend", Proficiency = 80, OrderIndex = 2 },
                    new() { Name = "Entity Framework", Category = "Backend", Proficiency = 78, OrderIndex = 3 },
                    new() { Name = "PostgreSQL", Category = "Database", Proficiency = 75, OrderIndex = 4 },
                    new() { Name = "JavaScript", Category = "Frontend", Proficiency = 80, OrderIndex = 5 },
                    new() { Name = "HTML/CSS", Category = "Frontend", Proficiency = 85, OrderIndex = 6 },
                    new() { Name = "Git", Category = "Tools", Proficiency = 80, OrderIndex = 7 },
                    new() { Name = "Docker", Category = "Tools", Proficiency = 60, OrderIndex = 8 },
                };
                db.Skills.AddRange(skills);
            }

            if (!db.Projects.Any())
            {
                db.Projects.Add(new Project
                {
                    TitleTR = "Örnek Proje",
                    TitleEN = "Sample Project",
                    DescriptionTR = "Bu proje ASP.NET Core ve PostgreSQL kullanılarak geliştirilmiştir.",
                    DescriptionEN = "This project was developed using ASP.NET Core and PostgreSQL.",
                    GithubUrl = "https://github.com/buselinyaman",
                    TechStack = "[\"C#\",\"ASP.NET Core\",\"PostgreSQL\"]",
                    IsFeatured = true,
                    OrderIndex = 1
                });
            }

            db.SaveChanges();
        }
    }
}
