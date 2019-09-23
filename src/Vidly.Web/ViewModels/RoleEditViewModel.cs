using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.ViewModels
{
    public class RoleEditViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
        public string RoleDescription { get; set; }
    }
}