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
    /// Our API methods to perform actions on Movie Genre DTOs.
    /// </summary>
    public class MovieGenreCodesController : ApiController
    {
        private readonly VidlyDbContext _context;

        public MovieGenreCodesController()
        {
            _context = new VidlyDbContext();
        }

        /// <summary>
        /// Call this API method to retrieve a list of all movie genre codes.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetMovieGenreCodes()
        {
            var movieGenreCodeDtos = _context.MovieGenreCodes
                .ToList()
                .Select(Mapper.Map<MovieGenreCode, MovieGenreCodeDto>);

            return Ok(movieGenreCodeDtos);
        }

        public IHttpActionResult GetMovieGenreCode(int id)
        {
            var movieGenreCode = _context.MovieGenreCodes
                .SingleOrDefault(m => m.Id == id);

            if (movieGenreCode == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<MovieGenreCode, MovieGenreCodeDto>(movieGenreCode));
        }

    }
}
