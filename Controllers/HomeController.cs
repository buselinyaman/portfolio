using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Services;

namespace PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _service;

        public HomeController(IPortfolioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _service.GetProjectsAsync();
            var events = await _service.GetSocialEventsAsync();
            var skills = await _service.GetSkillsAsync();
            var about = await _service.GetAboutInfoAsync();

            ViewBag.Projects = projects;
            ViewBag.Events = events;
            ViewBag.Skills = skills;
            ViewBag.About = about;

            return View();
        }
    }
}
