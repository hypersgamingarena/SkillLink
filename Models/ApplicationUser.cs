using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using SkillLinkCMS.Services;

public class ApplicationUser : IdentityUser
{
    public bool IsFeatured { get; set; }
    // Add additional properties for your user if needed
}
