using AutoMapper;
using SFFinalBlog2.BLL.ViewModels.Comments;
using SFFinalBlog2.DAL.Models;
using SFFinalBlog2.BLL.ViewModels.Posts;
using SFFinalBlog2.BLL.ViewModels.Tags;
using SFFinalBlog2.BLL.ViewModels.Users;

namespace API.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<CommentEditViewModel, Comment>();
            CreateMap<PostCreateViewModel, Post>();
            CreateMap<PostEditViewModel, Post>();
            CreateMap<TagCreateViewModel, Tag>();
            CreateMap<TagEditViewModel, Tag>();
            CreateMap<UserEditViewModel, User>();
        }
    }
}
