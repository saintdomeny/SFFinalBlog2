﻿using Microsoft.AspNetCore.Identity;

namespace SFFinalBlog2.DAL.Models
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
