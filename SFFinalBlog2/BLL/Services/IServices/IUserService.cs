using Microsoft.AspNetCore.Identity;
using SFFinalBlog2.BLL.ViewModels.Users;
using SFFinalBlog2.DAL.Models;

namespace SFFinalBlog2.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegisterViewModel model);

        Task<IdentityResult> CreateUser(UserCreateViewModel model);

        Task<SignInResult> Login(UserLoginViewModel model);

        Task<IdentityResult> EditAccount(UserEditViewModel model);

        Task<UserEditViewModel> EditAccount(Guid id);

        Task RemoveAccount(Guid id);

        Task<List<User>> GetAccounts();

        Task<User> GetAccount(Guid id);

        Task LogoutAccount();
    }
}
