using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class MembershipTypeCode
    {
        [Required]
        [DisplayName("Id")]
        public byte MembershipTypeCodeId { get; set; }
        [Required]
        public string MembershipTypeDesc { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
