using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace SkillLinkCMS.Pages.Admin
{
    public class CitiesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CitiesModel(ApplicationDbContext context) => _context = context;

        public List<City> Cities { get; set; } = new();

        [BindProperty]
        public City NewCity { get; set; }

        public void OnGet() => Cities = _context.Cities.ToList();

        public IActionResult OnPost()
        {
            try
            {
                _context.Cities.Add(NewCity);
                _context.SaveChanges();
                return RedirectToPage();
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exception
                // You can log the exception or return a custom error message to the user
                ModelState.AddModelError(string.Empty, "There was an error saving the city. Please try again.");
                return Page();
            }
            catch (Exception ex)
            {
                // Catch other exceptions
                // Log the exception or show a more generic error message
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return Page();
            }
        }
    }
}
