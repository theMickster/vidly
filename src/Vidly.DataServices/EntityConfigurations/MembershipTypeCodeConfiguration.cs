using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class MembershipTypeCodeConfiguration : EntityTypeConfiguration<MembershipTypeCode>
    {
        public MembershipTypeCodeConfiguration()
        {

            ToTable("membership_type_codes", "codes");

            HasKey(m => m.MembershipTypeCodeId);

            Property(m => m.MembershipTypeCodeId)
                .HasColumnName("membership_type_code_id");

            Property(m => m.MembershipTypeDesc)
                .HasColumnName("membership_type_desc")
                .IsRequired();

            Property(m => m.SignUpFee)
                .HasColumnName("sign_up_fee");

            Property(m => m.DurationInMonths)
                .HasColumnName("duration_in_months");

            Property(m => m.DiscountRate)
                .HasColumnName("discount_rate");           
        }
    }
}
