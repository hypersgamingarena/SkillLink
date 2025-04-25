using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Services;
using Microsoft.EntityFrameworkCore;

namespace SkillLinkCMS.Pages.Admin
{
    public class SettingsModel : PageModel
    {
        private readonly SiteSettingsService _settingsService;

        public SettingsModel(SiteSettingsService settingsService) => _settingsService = settingsService;

        [BindProperty]
        public string SiteTitle { get; set; }
        [BindProperty]
        public string LogoUrl { get; set; }
        [BindProperty]
        public string FooterText { get; set; }

        public void OnGet()
        {
            SiteTitle = _settingsService.Get("SiteTitle");
            LogoUrl = _settingsService.Get("LogoUrl");
            FooterText = _settingsService.Get("FooterText");
        }

        public IActionResult OnPost()
        {
            try
            {
                // Update the settings using the service
                _settingsService.Update("SiteTitle", SiteTitle);
                _settingsService.Update("LogoUrl", LogoUrl);
                _settingsService.Update("FooterText", FooterText);

                // Redirect to the page after successful update
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions and log or handle them
                // You can log the exception (ex) to a file or a logging service
                ModelState.AddModelError(string.Empty, "An error occurred while updating the settings. Please try again.");
                return Page();
            }
        }
    }
}
