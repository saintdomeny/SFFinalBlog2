﻿using SFFinalBlog2.DAL.Models;
using SFFinalBlog2.DAL.Repositories.IRepositories;

namespace SFFinalBlog2.DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public HashSet<Tag> GetAllTags()
        {
            return _context.Tags.ToHashSet();
        }

        public Tag GetTag(Guid id)
        {
            return _context.Tags.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await SaveChangesAsync();
        }

        public async Task UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            await SaveChangesAsync();
        }

        public async Task RemoveTag(Guid id)
        {
            _context.Tags.Remove(GetTag(id));
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
