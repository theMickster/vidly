using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DataServices.Models;

namespace Vidly.Web.ViewModels
{
    public class MovieDetailsEditViewModel
    {
        public MovieDetail MovieDetail { get; set; }
        public IEnumerable<MovieGenreCode> MovieGenreCodes { get; set; }
    }
}