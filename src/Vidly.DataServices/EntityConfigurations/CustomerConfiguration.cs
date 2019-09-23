using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .IsUnicode(false);

            Property(c => c.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .IsUnicode(false);

            Property(c => c.Dob)
                .HasColumnName("dob");

            Property(c => c.EmailAddress)
                .HasColumnName("email_address");

            Property(c => c.MembershipTypeCodeId)
                .HasColumnName("membership_type_code_id")
                .IsOptional();

            Property(c => c.IsSubscribedToNewsletter)
                .HasColumnName("is_subscribed_to_newsletter");

            /*********************************************************************************
             * Configuring nullable foreign keys that don't follow the naming standard
             ********************************************************************************/
            HasOptional(c => c.MembershipTypeCode)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.MembershipTypeCodeId);

        }
    }
}
