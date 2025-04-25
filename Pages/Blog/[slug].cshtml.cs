using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillLinkCMS.Data;
using SkillLinkCMS.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace SkillLinkCMS.Pages.Blog
{
    public class _slug_Model : PageModel
    {
        private readonly ApplicationDbContext _context;
        public BlogPost Post { get; set; }

        public IActionResult OnGet(string slug)
        {
            try
            {
                // Attempt to fetch the blog post based on the slug
                Post = _context.BlogPosts.FirstOrDefault(p => p.Slug == slug);

                // If no post is found, return a NotFound result
                if (Post == null)
                {
                    return NotFound();
                }

                // If post is found, return the page with the post data
                return Page();
            }
            catch (Exception ex)
            {
                // Log the exception (optional: use a logging framework)
                // Add a model error with a generic message to inform the user
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving the blog post. Please try again.");
                return Page();
            }
        }
    }
}
