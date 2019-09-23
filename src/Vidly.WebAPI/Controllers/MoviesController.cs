using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;
using Vidly.WebAPI.Dtos;

namespace Vidly.WebAPI.Controllers
{
    /// <summary>
    /// Our API methods to perform actions on Movie DTOs.
    /// </summary>
    public class MoviesController : ApiController
    {
        private readonly VidlyDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        /// <summary>
        /// Call this API method to retrieve a list of all movies. 
        /// </summary>
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        /// <summary>
        /// Call this API method to retrieve a single movie by Id
        /// </summary>
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        /// <summary>
        /// Call this API method to create a single movie
        /// </summary>
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

    }
}
