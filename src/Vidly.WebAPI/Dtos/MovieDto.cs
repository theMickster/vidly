using System;

namespace Vidly.WebAPI.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public string MovieDescription { get; set; }
        public string MoviePlotSummary { get; set; }
        public int? MovieRatingCodeId { get; set; }
        public int? GenreId { get; set; }
        public MovieDetailDto MovieDetail { get; set; }
        public MovieGenreCodeDto MovieGenreCode { get; set; }
        public MovieRatingCodeDto MovieRatingCode { get; set; }
    }
}