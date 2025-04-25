using Microsoft.EntityFrameworkCore;

namespace SkillLinkCMS.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Skill { get; set; } = string.Empty;
        public int CityId { get; set; }
        public City City { get; set; }  //
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsFeatured { get; set; } = false;

    }
}
