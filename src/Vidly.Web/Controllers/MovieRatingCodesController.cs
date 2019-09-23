using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;

namespace Vidly.Web.Controllers
{
    public class MovieRatingCodesController : Controller
    {
        private VidlyDbContext _context;

        public MovieRatingCodesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MovieRatingCodes
        public ActionResult Index()
        {
            var movieRatingCodes = _context.MovieRatingCodes.ToList();

            return View(movieRatingCodes);
        }
    }
}