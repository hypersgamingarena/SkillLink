using SkillLinkCMS.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SkillLinkCMS.Data
{
    public class DbInitializer
    {
        public static void SeedSettings(ApplicationDbContext context)
        {
            if (!context.SiteSettings.Any())
            {
                context.SiteSettings.AddRange(
                    new SiteSetting { Key = "SiteTitle", Value = "SkillLink PK" },
                    new SiteSetting { Key = "LogoUrl", Value = "/logo.png" },
                    new SiteSetting { Key = "FooterText", Value = "© 2025 SkillLink" }
                );
                context.SaveChanges();
            }
        }
    }

}

