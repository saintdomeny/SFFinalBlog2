﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System;

namespace SFFinalBlog2.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        //public string Login { get; set; } = null!;
        public DateTime CreatedData { get; set; } = DateTime.Now;   // попробовать добавить

        public List<Post> Posts { get; set; } = new();
        public List<Role> Roles { get; set; } = new();
    }
}
