using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;

namespace Vidly.Web.Controllers
{
    public class MovieDetailsController : Controller
    {
        private VidlyDbContext _context = new VidlyDbContext();

        // GET: MovieDetails
        public ActionResult Index()
        {
            var movieDetails = _context.MovieDetails.Include(m => m.InstallmentCode).Include(m => m.Movie);
            return View(movieDetails.ToList());
        }

        // GET: MovieDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDetail movieDetail = _context.MovieDetails.Find(id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            return View(movieDetail);
        }

        // GET: MovieDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDetail movieDetail = _context.MovieDetails.Find(id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstallmentId = new SelectList(_context.InstallmentCodes, "Id", "Installment", movieDetail.InstallmentId);
            ViewBag.Id = new SelectList(_context.Movies, "Id", "MovieName", movieDetail.Id);
            return View(movieDetail);
        }

        // POST: MovieDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImdbUrl,Summary,StoryLine,IsActive,InstallmentId")] MovieDetail movieDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(movieDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.InstallmentId = new SelectList(_context.InstallmentCodes, "Id", "Installment", movieDetail.InstallmentId);
            ViewBag.Id = new SelectList(_context.Movies, "Id", "MovieName", movieDetail.Id);
            return View(movieDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
