using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeCodeId { get; set; }
        public virtual MembershipTypeCode MembershipTypeCode { get; set; }
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        /*****************************************************************************************
         * The following shows an exmaple of coverting to an expression bodied member.
         * You can use an expression body definition whenever the logic for any supported member, 
         *    such as a method or property, consists of a single expression.
         ****************************************************************************************/
        public string DisplayName => this.FirstName + " " + this.LastName;
    }
}