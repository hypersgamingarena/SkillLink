using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Models;
namespace SkillLinkCMS.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    //public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<SiteSetting> SiteSettings => Set<SiteSetting>();
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }


}
