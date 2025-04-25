using SkillLinkCMS.Data;
using SkillLinkCMS.Models;

namespace SkillLinkCMS.Services
{
    public class SiteSettingsService
    {
       

    
        private readonly ApplicationDbContext _context;
        public SiteSettingsService(ApplicationDbContext context) => _context = context;

        public string Get(string key)
        {
            return _context.SiteSettings.FirstOrDefault(s => s.Key == key)?.Value ?? "";
        }

        public void Update(string key, string value)
        {
            var setting = _context.SiteSettings.FirstOrDefault(s => s.Key == key);
            if (setting != null)
            {
                setting.Value = value;
                _context.SaveChanges();
            }
        }

        public Dictionary<string, string> GetAll()
        {
            return _context.SiteSettings.ToDictionary(s => s.Key, s => s.Value);
        }
    }

}

