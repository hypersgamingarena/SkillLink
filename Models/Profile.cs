using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillLinkCMS.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string Bio { get; set; } = string.Empty;
        [Required]
        public string Skills { get; set; } = string.Empty;
        public int CityId { get; set; }
        public City City { get; set; } 
        public string? ImageUrl { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public Profile? Profile { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
     public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
