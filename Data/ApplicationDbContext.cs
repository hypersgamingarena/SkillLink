using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SkillLinkCMS.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<FeaturedListing> FeaturedListings { get; set; }
    public DbSet<SiteSetting> SiteSettings => Set<SiteSetting>();
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }



public class Profile
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string Bio { get; set; }
    public string Skills { get; set; }
    [ForeignKey("City")]
    public int CityId { get; set; }
    public City City { get; set; }
    public string ImageUrl { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class FeaturedListing
{
    [ForeignKey("Profile")]
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }
    public bool IsFeatured { get; set; }
}

public class ApplicationUser : IdentityUser { }
</CODE_BLOCK>
}

