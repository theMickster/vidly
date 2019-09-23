using AutoMapper;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;
using Vidly.WebAPI.Dtos;

namespace Vidly.WebAPI.Controllers
{
    /// <summary>
    /// Our API methods to perform actions on Movie Details
    /// </summary>
    public class MovieDetailsController : ApiController
    {
        private readonly VidlyDbContext _context;

        public MovieDetailsController()
        {
            _context = new VidlyDbContext();
        }

        /// <summary>
        /// Call this API method to retrieve a list of all movie details
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetMovieDetails()
        {
            var movieDetailsDtos = _context.MovieDetails
                .ToList()
                .Select(Mapper.Map<MovieDetail, MovieDetailDto>);

            return Ok(movieDetailsDtos);
        }

        /// <summary>
        /// Call this API method to retrieve a single movie's details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetMovieDetail(int id)
        {
            var movieDetail = _context.MovieDetails
                .SingleOrDefault(m => m.Id == id);

            if(movieDetail == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<MovieDetail, MovieDetailDto>(movieDetail));
        }


    }
}
