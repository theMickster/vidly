namespace Vidly.WebAPI.Dtos
{
    public class MembershipTypeCodeDto
    {
        public byte MembershipTypeCodeId { get; set; }
        public string MembershipTypeDesc { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}