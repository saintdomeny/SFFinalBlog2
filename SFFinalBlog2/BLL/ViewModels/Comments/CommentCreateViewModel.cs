﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SFFinalBlog2.BLL.ViewModels.Comments
{
    public class CommentCreateViewModel
    {
        [Required(ErrorMessage = "Поле Содержание обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Содержание", Prompt = "Содержание")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Поле Автор обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Автор", Prompt = "Автор")]
        public string? Author { get; set; }

        public Guid PostId;
    }
}
