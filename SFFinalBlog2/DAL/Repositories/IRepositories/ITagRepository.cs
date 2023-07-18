using SFFinalBlog2.DAL.Models;

namespace SFFinalBlog2.DAL.Repositories.IRepositories
{
    public interface ITagRepository
    {
        HashSet<Tag> GetAllTags();

        Tag GetTag(Guid id);

        Task AddTag(Tag tag);

        Task UpdateTag(Tag tag);

        Task RemoveTag(Guid id);

        Task<bool> SaveChangesAsync();
    }
}
