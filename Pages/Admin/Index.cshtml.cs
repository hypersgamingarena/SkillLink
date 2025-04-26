using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;


namespace SkillLinkCMS.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostToggleFeaturedAsync(string userId)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile != null)
            {
                var featuredListing = await _context.FeaturedListings.FirstOrDefaultAsync(f => f.ProfileId == profile.Id);
                if (featuredListing != null)
                {
                    featuredListing.IsFeatured = !featuredListing.IsFeatured;
                    _context.FeaturedListings.Update(featuredListing);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage();
        }
    }
}
