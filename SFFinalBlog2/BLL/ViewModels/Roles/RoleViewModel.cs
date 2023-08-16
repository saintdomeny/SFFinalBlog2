using System.ComponentModel.DataAnnotations;

namespace SFFinalBlog2.BLL.ViewModels.Roles
{
    public class CommentViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
