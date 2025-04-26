using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SkillLinkCMS.Models;
using SkillLinkCMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SkillLinkCMS.Pages.Profile{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<CreateModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty] 
        public Profile Profile { get; set; }

        public List<Category> Categories { get; set; }
        public List<City> Cities { get; set; }

        // OnGet method to load categories and cities for the dropdown lists
        public void OnGet()
        {
            LoadCategoriesAndCities();
        } 

        // OnPostAsync method to handle the form submission
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the model is invalid, reload Categories and Cities
                LoadCategoriesAndCities();
                return Page();
            }

            try
            {
                // Ensure the current user is available
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    // Redirect to login page if user is not authenticated
                    return RedirectToPage("/Account/Login");
                }

                // Check if the profile already exists for the user
                var existingProfile = await _context.Profiles
                    .FirstOrDefaultAsync(p => p.UserId == userId);
                if (existingProfile != null)
                {
                    // Handle the case where the user already has a profile
                    ModelState.AddModelError(string.Empty, "You already have a profile.");
                    LoadCategoriesAndCities();
                    return Page(); 
                } 

                // Set the UserId for the profile and add it to the context
                Profile.UserId = userId; 
                _context.Profiles.Add(Profile); 

                // Save the profile to the database
                await _context.SaveChangesAsync(); 
                // Redirect to the View page of the created profile
                return RedirectToPage("/Profile/View", new { id = Profile.Id });
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database update exception
                _logger.LogError(dbEx, "Database error occurred while creating the profile.");
                ModelState.AddModelError(string.Empty, "A database error occurred while creating your profile. Please try again later.");
                LoadCategoriesAndCities();
                return Page();
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                _logger.LogError(ex, "An unexpected error occurred while creating the profile.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while creating the profile. Please try again later.");
                LoadCategoriesAndCities();
                return Page();
            }
        }

        // Helper method to load categories and cities
        private void LoadCategoriesAndCities()
        {
            Categories = _context.Categories.ToList();
            Cities = _context.Cities.ToList();
        }
    }

}
