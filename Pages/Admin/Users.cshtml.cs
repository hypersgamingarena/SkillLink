using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using System;

namespace SkillLinkCMS.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UsersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> Users { get; set; } = new();

        // Fetch users from the database asynchronously
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Users = await _context.Users.OfType<ApplicationUser>().ToListAsync();
                return Page();
            }
            catch (Exception ex)
            {
                // Log exception (Optional: log the error using a logging service)
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the users. Please try again.");
                return Page();
            }
        }

        // Handle feature toggle and update the database asynchronously
        public async Task<IActionResult> OnPostFeatureAsync(int id)
        {
            try
            {
                var profile = await _context.Profiles.FindAsync(id);

                if (profile == null)
                {
                    // If profile not found, return a not found result
                    return NotFound();
                }

                // Toggle the IsFeatured status
                profile.IsFeatured = !profile.IsFeatured;

                // Save changes asynchronously
                await _context.SaveChangesAsync();

                // Redirect to the same page
                return RedirectToPage();
            }
            catch (DbUpdateException ex)
            {
                // Handle database-related exceptions
                ModelState.AddModelError(string.Empty, "An error occurred while updating the profile. Please try again.");
                return Page();
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return Page();
            }
        }
    }
}
