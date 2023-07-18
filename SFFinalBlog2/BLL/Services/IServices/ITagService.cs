using SFFinalBlog2.BLL.ViewModels.Tags;
using SFFinalBlog2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFinalBlog2.BLL.Services.IServices
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateViewModel model);

        Task<TagEditViewModel> EditTag(Guid id);

        Task EditTag(TagEditViewModel model, Guid id);

        Task RemoveTag(Guid id);

        Task<List<Tag>> GetTags();

        Task<Tag> GetTag(Guid id);
    }
}
