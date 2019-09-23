using System.Linq;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;

namespace Vidly.Web.Controllers
{
    public class MovieGenreCodesController : Controller
    {
        private readonly VidlyDbContext _context;

        public MovieGenreCodesController()
        {
            _context = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movieGenreCodes = _context.MovieGenreCodes.ToList();

            return View(movieGenreCodes);
        }

    }
}