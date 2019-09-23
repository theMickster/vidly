using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(r => r.Id);
            //HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
        }
    }
}
