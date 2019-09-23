using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vidly.Web.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        public string DriversLicenseId { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}