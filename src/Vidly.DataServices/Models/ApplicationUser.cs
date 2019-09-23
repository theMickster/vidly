using System.ComponentModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Vidly.DataServices.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        [DisplayName("Drivers License Number")]
        public string DriversLicenseId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName => FirstName + " " + LastName;
    }
}