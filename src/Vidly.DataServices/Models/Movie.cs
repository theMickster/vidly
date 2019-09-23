using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.DataServices.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }        
        public int? Runtime { get; set; }
        [StringLength(500)]
        public string MovieDescription { get; set; }
        public string MoviePlotSummary { get; set; }
        public virtual int? MovieRatingCodeId { get; set; }
        public virtual int? GenreId { get; set; }
        public virtual MovieGenreCode MovieGenreCode { get; set; }        
        public virtual MovieRatingCode MovieRatingCode { get; set; }
        public virtual MovieDetail MovieDetail { get; set; }
    }
}