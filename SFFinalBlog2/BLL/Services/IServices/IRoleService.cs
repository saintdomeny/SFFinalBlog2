using SFFinalBlog2.BLL.ViewModels.Roles;
using SFFinalBlog2.DAL.Models;

namespace SFFinalBlog2.BLL.Services.IServices
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateViewModel model);

        Task EditRole(RoleEditViewModel model);

        Task RemoveRole(Guid id);

        Task<List<Role>> GetRoles();

        Task<Role?> GetRole(Guid id);
    }
}
