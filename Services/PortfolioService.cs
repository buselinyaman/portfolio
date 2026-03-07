//using PortfolioSite.Data;
//using PortfolioSite.Models;
//using Microsoft.EntityFrameworkCore;

//namespace PortfolioSite.Services
//{
//    public interface IPortfolioService
//    {
//        Task<List<Project>> GetProjectsAsync();
//        Task<Project?> GetProjectByIdAsync(int id);
//        Task<Project> CreateProjectAsync(Project project);
//        Task<Project> UpdateProjectAsync(Project project);
//        Task DeleteProjectAsync(int id);

//        Task<List<SocialEvent>> GetSocialEventsAsync();
//        Task<SocialEvent?> GetSocialEventByIdAsync(int id);
//        Task<SocialEvent> CreateSocialEventAsync(SocialEvent socialEvent);
//        Task<SocialEvent> UpdateSocialEventAsync(SocialEvent socialEvent);
//        Task DeleteSocialEventAsync(int id);

//        Task<List<Skill>> GetSkillsAsync();
//        Task<Skill> CreateSkillAsync(Skill skill);
//        Task<Skill> UpdateSkillAsync(Skill skill);
//        Task DeleteSkillAsync(int id);

//        Task<AboutInfo> GetAboutInfoAsync();
//        Task<AboutInfo> UpdateAboutInfoAsync(AboutInfo aboutInfo);
//    }

//    public class PortfolioService : IPortfolioService
//    {
//        private readonly AppDbContext _db;

//        public PortfolioService(AppDbContext db)
//        {
//            _db = db;
//        }

//        // Projects
//        public async Task<List<Project>> GetProjectsAsync() =>
//            await _db.Projects.OrderBy(p => p.OrderIndex).ToListAsync();

//        public async Task<Project?> GetProjectByIdAsync(int id) =>
//            await _db.Projects.FindAsync(id);

//        public async Task<Project> CreateProjectAsync(Project project)
//        {
//            project.CreatedAt = DateTime.UtcNow;
//            project.UpdatedAt = DateTime.UtcNow;
//            _db.Projects.Add(project);
//            await _db.SaveChangesAsync();
//            return project;
//        }

//        public async Task<Project> UpdateProjectAsync(Project project)
//        {
//            project.UpdatedAt = DateTime.UtcNow;
//            _db.Projects.Update(project);
//            await _db.SaveChangesAsync();
//            return project;
//        }

//        public async Task DeleteProjectAsync(int id)
//        {
//            var project = await _db.Projects.FindAsync(id);
//            if (project != null)
//            {
//                _db.Projects.Remove(project);
//                await _db.SaveChangesAsync();
//            }
//        }

//        // Social Events
//        public async Task<List<SocialEvent>> GetSocialEventsAsync() =>
//            await _db.SocialEvents.OrderByDescending(e => e.EventDate).ToListAsync();

//        public async Task<SocialEvent?> GetSocialEventByIdAsync(int id) =>
//            await _db.SocialEvents.FindAsync(id);

//        public async Task<SocialEvent> CreateSocialEventAsync(SocialEvent socialEvent)
//        {
//            socialEvent.CreatedAt = DateTime.UtcNow;
//            socialEvent.UpdatedAt = DateTime.UtcNow;
//            _db.SocialEvents.Add(socialEvent);
//            await _db.SaveChangesAsync();
//            return socialEvent;
//        }

//        public async Task UpdateSocialEventAsync(SocialEvent socialEvent)
//        {
//            var existingEvent = await _db.SocialEvents.FindAsync(socialEvent.Id);

//            if (existingEvent == null)
//                throw new InvalidOperationException("Event not found.");

//            _db.Entry(existingEvent).CurrentValues.SetValues(socialEvent);
//            await _db.SaveChangesAsync();
//        }

//        public async Task DeleteSocialEventAsync(int id)
//        {
//            var ev = await _db.SocialEvents.FindAsync(id);
//            if (ev != null)
//            {
//                _db.SocialEvents.Remove(ev);
//                await _db.SaveChangesAsync();
//            }
//        }

//        // Skills
//        public async Task<List<Skill>> GetSkillsAsync() =>
//            await _db.Skills.OrderBy(s => s.OrderIndex).ToListAsync();

//        public async Task<Skill> CreateSkillAsync(Skill skill)
//        {
//            _db.Skills.Add(skill);
//            await _db.SaveChangesAsync();
//            return skill;
//        }

//        public async Task UpdateSkillsAsync(Skill skill)
//        {
//            var existingSkill = await _db.Skills.FindAsync(skill.Id);

//            if (existingSkill == null)
//                throw new InvalidOperationException("Skill not found.");

//            _db.Entry(existingSkill).CurrentValues.SetValues(skill);
//            await _db.SaveChangesAsync();
//        }

//        public async Task DeleteSkillAsync(int id)
//        {
//            var skill = await _db.Skills.FindAsync(id);
//            if (skill != null)
//            {
//                _db.Skills.Remove(skill);
//                await _db.SaveChangesAsync();
//            }
//        }

//        // About
//        public async Task<AboutInfo> GetAboutInfoAsync()
//        {
//            var info = await _db.AboutInfos.FirstOrDefaultAsync();
//            if (info == null)
//            {
//                info = new AboutInfo();
//                _db.AboutInfos.Add(info);
//                await _db.SaveChangesAsync();
//            }
//            return info;
//        }

//        public async Task UpdateAboutInfoAsync(AboutInfo aboutinfo)
//        {
//            var existingAboutInfo = await _db.Skills.FindAsync(aboutinfo.Id);

//            if (existingAboutInfo == null)
//                throw new InvalidOperationException("About Info not found.");

//            _db.Entry(existingAboutInfo).CurrentValues.SetValues(AboutInfo aboutinfo);
//            await _db.SaveChangesAsync();
//        }
//    }
//}
using PortfolioSite.Data;
using PortfolioSite.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioSite.Services
{
    public interface IPortfolioService
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);

        Task<List<SocialEvent>> GetSocialEventsAsync();
        Task<SocialEvent?> GetSocialEventByIdAsync(int id);
        Task<SocialEvent> CreateSocialEventAsync(SocialEvent socialEvent);
        Task<SocialEvent> UpdateSocialEventAsync(SocialEvent socialEvent);
        Task DeleteSocialEventAsync(int id);

        Task<List<Skill>> GetSkillsAsync();
        Task<Skill> CreateSkillAsync(Skill skill);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(int id);

        Task<AboutInfo> GetAboutInfoAsync();
        Task<AboutInfo> UpdateAboutInfoAsync(AboutInfo aboutInfo);
    }

    public class PortfolioService : IPortfolioService
    {
        private readonly AppDbContext _db;

        public PortfolioService(AppDbContext db)
        {
            _db = db;
        }

        // Projects
        public async Task<List<Project>> GetProjectsAsync() =>
            await _db.Projects.OrderBy(p => p.OrderIndex).ToListAsync();

        public async Task<Project?> GetProjectByIdAsync(int id) =>
            await _db.Projects.FindAsync(id);

        public async Task<Project> CreateProjectAsync(Project project)
        {
            project.CreatedAt = DateTime.UtcNow;
            project.UpdatedAt = DateTime.UtcNow;
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            project.UpdatedAt = DateTime.UtcNow;
            _db.Projects.Update(project);
            await _db.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                await _db.SaveChangesAsync();
            }
        }

        // Social Events
        public async Task<List<SocialEvent>> GetSocialEventsAsync() =>
            await _db.SocialEvents.OrderByDescending(e => e.EventDate).ToListAsync();

        public async Task<SocialEvent?> GetSocialEventByIdAsync(int id) =>
            await _db.SocialEvents.FindAsync(id);

        public async Task<SocialEvent> CreateSocialEventAsync(SocialEvent socialEvent)
        {
            socialEvent.CreatedAt = DateTime.UtcNow;
            socialEvent.UpdatedAt = DateTime.UtcNow;
            _db.SocialEvents.Add(socialEvent);
            await _db.SaveChangesAsync();
            return socialEvent;
        }

        public async Task<SocialEvent> UpdateSocialEventAsync(SocialEvent socialEvent)
        {
            var existingEvent = await _db.SocialEvents.FindAsync(socialEvent.Id);

            if (existingEvent == null)
                throw new InvalidOperationException("Event not found.");

            _db.Entry(existingEvent).CurrentValues.SetValues(socialEvent);
            existingEvent.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return existingEvent;
        }

        public async Task DeleteSocialEventAsync(int id)
        {
            var ev = await _db.SocialEvents.FindAsync(id);
            if (ev != null)
            {
                _db.SocialEvents.Remove(ev);
                await _db.SaveChangesAsync();
            }
        }

        // Skills
        public async Task<List<Skill>> GetSkillsAsync() =>
            await _db.Skills.OrderBy(s => s.OrderIndex).ToListAsync();

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            _db.Skills.Add(skill);
            await _db.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            var existingSkill = await _db.Skills.FindAsync(skill.Id);

            if (existingSkill == null)
                throw new InvalidOperationException("Skill not found.");

            _db.Entry(existingSkill).CurrentValues.SetValues(skill);
            await _db.SaveChangesAsync();
            return existingSkill;
        }

        public async Task DeleteSkillAsync(int id)
        {
            var skill = await _db.Skills.FindAsync(id);
            if (skill != null)
            {
                _db.Skills.Remove(skill);
                await _db.SaveChangesAsync();
            }
        }

        // About
        public async Task<AboutInfo> GetAboutInfoAsync()
        {
            var info = await _db.AboutInfos.FirstOrDefaultAsync();
            if (info == null)
            {
                info = new AboutInfo();
                _db.AboutInfos.Add(info);
                await _db.SaveChangesAsync();
            }
            return info;
        }

        public async Task<AboutInfo> UpdateAboutInfoAsync(AboutInfo aboutInfo)
        {
            var existingAboutInfo = await _db.AboutInfos.FindAsync(aboutInfo.Id);

            if (existingAboutInfo == null)
                throw new InvalidOperationException("About info not found.");

            _db.Entry(existingAboutInfo).CurrentValues.SetValues(aboutInfo);
            await _db.SaveChangesAsync();
            return existingAboutInfo;
        }
    }
}