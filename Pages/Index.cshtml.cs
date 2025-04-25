using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SkillLinkCMS.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public List<UserProfile> Profiles { get; set; }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CityId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        public void OnGet()
        {
            Cities = _context.Cities.ToList();
            Categories = _context.Categories.ToList();

            var query = _context.Profiles
                .Include(p => p.City)
                .Include(p => p.Category)
                .Where(p => p.IsFeatured);

            if (CityId > 0) query = query.Where(p => p.CityId == CityId);
            if (CategoryId > 0) query = query.Where(p => p.CategoryId == CategoryId);

            Profiles = query.ToList();
        }
    }

}