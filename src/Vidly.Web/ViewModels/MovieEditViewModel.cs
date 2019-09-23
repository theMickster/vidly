using System.Collections.Generic;
using Vidly.DataServices.Models;

namespace Vidly.Web.ViewModels
{
    public class MovieEditViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieGenreCode> MovieGenreCodes { get; set; }
        public IEnumerable<MovieRatingCode> MovieRatingCodes { get; set; }
    }
}