﻿using Microsoft.EntityFrameworkCore;


namespace SkillLinkCMS.Models
{
    public class SiteSetting
    {
        
            public int Id { get; set; }
            public string Key { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
        

    }
}
