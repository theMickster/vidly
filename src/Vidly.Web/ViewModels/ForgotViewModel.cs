using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}