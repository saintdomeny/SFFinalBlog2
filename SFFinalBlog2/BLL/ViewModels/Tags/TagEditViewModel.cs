using System.ComponentModel.DataAnnotations;

namespace SFFinalBlog2.BLL.ViewModels.Tags
{
    public class TagEditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string? Name { get; set; }
    }
}
