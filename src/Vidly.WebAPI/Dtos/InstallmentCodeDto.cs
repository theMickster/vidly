namespace Vidly.WebAPI.Dtos
{
    public class InstallmentCodeDto
    {
        public int Id { get; set; }
        public string Installment { get; set; }
        public bool IsActive { get; set; }
    }
}