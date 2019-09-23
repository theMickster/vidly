using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class MovieRatingCode
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Rating { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
