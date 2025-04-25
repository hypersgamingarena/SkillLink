using Microsoft.EntityFrameworkCore;

namespace SkillLinkCMS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}
