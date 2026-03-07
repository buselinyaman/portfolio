using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Models;
using PortfolioSite.Services;
using System.Security.Claims;
using System.Text.Json;

namespace PortfolioSite.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuth")]
    public class AdminController : Controller
    {
        private readonly IPortfolioService _service;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public AdminController(IPortfolioService service, IConfiguration config, IWebHostEnvironment env)
        {
            _service = service;
            _config = config;
            _env = env;
        }

        // AUTH

        // AUTH
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Dashboard");

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var adminUser = _config["AdminCredentials:Username"];
            var adminPass = _config["AdminCredentials:Password"];

            if (username == adminUser && password == adminPass)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("CookieAuth", principal);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        // DASHBOARD
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ProjectCount = (await _service.GetProjectsAsync()).Count;
            ViewBag.EventCount = (await _service.GetSocialEventsAsync()).Count;
            ViewBag.SkillCount = (await _service.GetSkillsAsync()).Count;
            return View();
        }

        // PROJECTS 
        public async Task<IActionResult> Projects()
        {
            var projects = await _service.GetProjectsAsync();
            return View(projects);
        }

        [HttpGet]
        public IActionResult CreateProject() => View(new Project());

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project, IFormFile? imageFile, string techStackInput)
        {
            if (imageFile != null)
                project.ImagePath = await SaveImageAsync(imageFile, "projects");

            project.TechStack = string.IsNullOrEmpty(techStackInput)
                ? "[]"
                : JsonSerializer.Serialize(techStackInput.Split(',').Select(t => t.Trim()).ToArray());

            await _service.CreateProjectAsync(project);
            TempData["Success"] = "Proje başarıyla eklendi.";
            return RedirectToAction("Projects");
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _service.GetProjectByIdAsync(id);
            if (project == null) return NotFound();

            var techList = JsonSerializer.Deserialize<List<string>>(project.TechStack ?? "[]") ?? new();
            ViewBag.TechStackString = string.Join(", ", techList);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project project, IFormFile? imageFile, string techStackInput)
        {
            var existing = await _service.GetProjectByIdAsync(project.Id);
            if (existing == null) return NotFound();

            if (imageFile != null)
                project.ImagePath = await SaveImageAsync(imageFile, "projects");
            else
                project.ImagePath = existing.ImagePath;

            project.TechStack = string.IsNullOrEmpty(techStackInput)
                ? "[]"
                : JsonSerializer.Serialize(techStackInput.Split(',').Select(t => t.Trim()).ToArray());

            project.CreatedAt = existing.CreatedAt;
            await _service.UpdateProjectAsync(project);
            TempData["Success"] = "Proje güncellendi.";
            return RedirectToAction("Projects");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _service.DeleteProjectAsync(id);
            TempData["Success"] = "Proje silindi.";
            return RedirectToAction("Projects");
        }

        // SOCIAL EVENTS
        public async Task<IActionResult> Events()
        {
            var events = await _service.GetSocialEventsAsync();
            return View(events);
        }

        [HttpGet]
        public IActionResult CreateEvent() => View(new SocialEvent());

        [HttpPost]
        public async Task<IActionResult> CreateEvent(SocialEvent socialEvent, IFormFile? imageFile)
        {
            if (imageFile != null)
                socialEvent.ImagePath = await SaveImageAsync(imageFile, "events");

            await _service.CreateSocialEventAsync(socialEvent);
            TempData["Success"] = "Etkinlik eklendi.";
            return RedirectToAction("Events");
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            var ev = await _service.GetSocialEventByIdAsync(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(SocialEvent socialEvent, IFormFile? imageFile)
        {
            var existing = await _service.GetSocialEventByIdAsync(socialEvent.Id);
            if (existing == null) return NotFound();

            if (imageFile != null)
                socialEvent.ImagePath = await SaveImageAsync(imageFile, "events");
            else
                socialEvent.ImagePath = existing.ImagePath;

            socialEvent.CreatedAt = existing.CreatedAt;
            await _service.UpdateSocialEventAsync(socialEvent);
            TempData["Success"] = "Etkinlik güncellendi.";
            return RedirectToAction("Events");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _service.DeleteSocialEventAsync(id);
            TempData["Success"] = "Etkinlik silindi.";
            return RedirectToAction("Events");
        }

        // SKILLS
        public async Task<IActionResult> Skills()
        {
            var skills = await _service.GetSkillsAsync();
            return View(skills);
        }

        [HttpGet]
        public IActionResult CreateSkill() => View(new Skill());

        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            await _service.CreateSkillAsync(skill);
            TempData["Success"] = "Yetenek eklendi.";
            return RedirectToAction("Skills");
        }

        [HttpGet]
        public async Task<IActionResult> EditSkill(int id)
        {
            var skill = await _service.GetSkillsAsync();
            var s = skill.FirstOrDefault(x => x.Id == id);
            if (s == null) return NotFound();
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> EditSkill(Skill skill)
        {
            await _service.UpdateSkillAsync(skill);
            TempData["Success"] = "Yetenek güncellendi.";
            return RedirectToAction("Skills");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _service.DeleteSkillAsync(id);
            TempData["Success"] = "Yetenek silindi.";
            return RedirectToAction("Skills");
        }

        // ABOUT
        public async Task<IActionResult> About()
        {
            var about = await _service.GetAboutInfoAsync();
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> About(AboutInfo aboutInfo, IFormFile? profileImage)
        {
            var existing = await _service.GetAboutInfoAsync();
            aboutInfo.Id = existing.Id;

            if (profileImage != null)
                aboutInfo.ProfileImagePath = await SaveImageAsync(profileImage, "profile");
            else
                aboutInfo.ProfileImagePath = existing.ProfileImagePath;

            await _service.UpdateAboutInfoAsync(aboutInfo);
            TempData["Success"] = "Hakkımda bilgileri güncellendi.";
            return RedirectToAction("About");
        }

        // HELPER 
        private async Task<string> SaveImageAsync(IFormFile file, string folder)
        {
            var uploadsPath = Path.Combine(_env.WebRootPath, "images", folder);
            Directory.CreateDirectory(uploadsPath);

            var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsPath, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/images/{folder}/{uniqueName}";
        }
    }
}
