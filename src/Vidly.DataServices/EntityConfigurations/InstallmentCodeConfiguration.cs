using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class InstallmentCodeConfiguration : EntityTypeConfiguration<InstallmentCode>
    {
        public InstallmentCodeConfiguration()
        {
            ToTable("installment_codes", "codes ");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("installment_id")
                .IsRequired();

            Property(m => m.Installment)
                .HasColumnName("installment_desc")
                .IsRequired();

            Property(m => m.IsActive)
                .HasColumnName("active_flag")
                .IsRequired();

        }

    }
}
