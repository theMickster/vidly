using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class MovieDetail
    {
        [Required]
        public int Id { get; set; }
        public string ImdbUrl { get; set; }
        public string Summary { get; set; }
        public string StoryLine { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int? InstallmentId { get; set; }
        public virtual InstallmentCode InstallmentCode { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
