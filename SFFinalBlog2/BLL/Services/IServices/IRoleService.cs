using SFFinalBlog2.BLL.ViewModels.Roles;
using SFFinalBlog2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
