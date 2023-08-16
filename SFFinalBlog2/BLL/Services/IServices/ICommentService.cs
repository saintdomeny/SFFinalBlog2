using SFFinalBlog2.BLL.ViewModels.Comments;
using SFFinalBlog2.DAL.Models;

namespace SFFinalBlog2.BLL.Services.IServices
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateViewModel model, Guid userId);

        Task RemoveComment(Guid id);

        Task<List<Comment>> GetComments();
        Task<Comment> GetComment(Guid id);//

        Task<CommentEditViewModel> EditComment(Guid id);

        Task EditComment(CommentEditViewModel model, Guid id);
    }
}
