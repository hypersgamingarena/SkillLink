using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SkillLinkCMS.Pages.Profile
{
    [AllowAnonymous]
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ViewModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;        public ViewModel(ApplicationDbContext context, ILogger<ViewModel> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
        }

        public UserProfile Profile { get; set; }
        public bool IsOwnProfile { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Profile = await _context.Profiles
                .Include(p => p.City)
                .FirstOrDefaultAsync(p => p.Id == id);

                if (Profile == null)
                {
                    return NotFound();
                }
                
                 var user = await _userManager.GetUserAsync(User);

                if(user != null) {
                    IsOwnProfile = Profile.UserId == user.Id;
                }
                
                if (!IsOwnProfile) {
                  if (Profile.IsPublic == false)
                  {
                    return Forbid();
                  }
                }

                return  Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the profile with ID: {ProfileId}", id);
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the profile. Please try again later.");

                return  Page();
            }
        }
    }
}
