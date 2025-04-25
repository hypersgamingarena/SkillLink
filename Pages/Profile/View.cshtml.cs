using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Data;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Models;
using Microsoft.Extensions.Logging;
using System;

namespace SkillLinkCMS.Pages.Profile
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ViewModel> _logger;

        // Constructor to inject the context and logger
        public ViewModel(ApplicationDbContext context, ILogger<ViewModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public UserProfile Profile { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                // Attempt to fetch the profile from the database, including related City and Category
                Profile = _context.Profiles
                    .Include(p => p.City)
                    .Include(p => p.Category)
                    .FirstOrDefault(p => p.Id == id);

                // If profile is not found, return NotFound result
                if (Profile == null)
                {
                    return NotFound();
                }

                return Page();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while fetching the profile with ID: {ProfileId}", id);

                // Return an error message to the user
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the profile. Please try again later.");

                // Optionally, you can redirect to a custom error page or return the current page
                return Page();
            }
        }
    }
}
