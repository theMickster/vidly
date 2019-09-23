using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Web.ViewModels;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenreCode).Include(m => m.MovieRatingCode).ToList();

            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id) ?? new Movie();

            var viewModel = new MovieEditViewModel
            {
                Movie = movie,
                MovieRatingCodes = _context.MovieRatingCodes.ToList(),
                MovieGenreCodes = _context.MovieGenreCodes.ToList()                
            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieEditViewModel
                {
                    Movie = movie,
                    MovieRatingCodes = _context.MovieRatingCodes.ToList(),
                    MovieGenreCodes = _context.MovieGenreCodes.ToList()
                };
                return View("Edit", viewModel);
            }

            if (movie.Id == 0)
            {                
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Runtime = movie.Runtime;
                movieInDb.MovieDescription = movie.MovieDescription;
                movieInDb.MoviePlotSummary = movie.MoviePlotSummary;
                movieInDb.MovieRatingCodeId = movie.MovieRatingCodeId;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id) ?? new Movie();

            return PartialView("_ViewMovieDetails", movie);
        }
    }
}