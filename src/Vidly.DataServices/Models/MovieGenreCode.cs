using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DataServices.Models
{
    public class MovieGenreCode
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
