using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SFFinalBlog2.BLL.ViewModels.Roles
{
    public class RoleViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
