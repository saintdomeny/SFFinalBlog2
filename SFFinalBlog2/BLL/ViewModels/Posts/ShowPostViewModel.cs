﻿namespace SFFinalBlog2.BLL.ViewModels.Posts
{
    public class ShowPostViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? AuthorId { get; set; }

        public IEnumerable<string>? Tags { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}
