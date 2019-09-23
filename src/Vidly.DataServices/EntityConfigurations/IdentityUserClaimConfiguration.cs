using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.DataServices.EntityConfigurations
{
    internal class IdentityUserClaimConfiguration : EntityTypeConfiguration<IdentityUserClaim>
    {
        internal IdentityUserClaimConfiguration()
        {
            ToTable("AspNetUserClaims");

            HasRequired(t => t.UserId)
                .WithMany()
                .HasForeignKey(m => m.UserId);

        }
    }
}
