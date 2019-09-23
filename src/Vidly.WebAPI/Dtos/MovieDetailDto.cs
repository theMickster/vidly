namespace Vidly.WebAPI.Dtos
{
    public class MovieDetailDto
    {
        public int Id { get; set; }
        public string ImdbUrl { get; set; }
        public string Summary { get; set; }
        public string StoryLine { get; set; }
        public bool IsActive { get; set; }
        public int? InstallmentId { get; set; }
        public InstallmentCodeDto InstallmentCode { get; set; }
    }
}