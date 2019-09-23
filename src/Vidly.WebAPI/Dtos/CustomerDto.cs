using System;

namespace Vidly.WebAPI.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string EmailAddress { get; set; }
        public byte? MembershipTypeCodeId { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeCodeDto MembershipTypeCode { get; set; }
    }
}