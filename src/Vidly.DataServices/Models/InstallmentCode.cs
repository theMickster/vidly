using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class InstallmentCode
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Installment { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }
    }
}
