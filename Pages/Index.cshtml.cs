using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkillLinkCMS.Models;
using SkillLinkCMS.Data;


namespace SkillLinkCMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public List<Profile> Profiles { get; set; }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Skill { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CityId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        public void OnGet()
        {
            Cities = _context.Cities.ToList();
            Categories = _context.Categories.ToList();            
            var query = _context.FeaturedListings
                .Include(fl => fl.Profile)
                    .ThenInclude(p=>p.City)
                .Include(fl => fl.Profile)
                    .ThenInclude(p=>p.Category)
                .Where(fl => fl.IsFeatured)
                .Select(fl => fl.Profile);

            if (CityId > 0) query = query.Where(p => p.CityId == CityId);
            if (CategoryId > 0) query = query.Where(p => p.CategoryId == CategoryId);           
            if (!string.IsNullOrEmpty(Skill))
            {
                query = query.Where(p => p.Skills.Contains(Skill));
            }

            Profiles = query.ToList();
        }
    }

}