using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;
using Vidly.WebAPI.Dtos;

namespace Vidly.WebAPI.Controllers
{
    /// <summary>
    /// Our API methods to perform actions on Movie Rating Code DTOs.
    /// </summary>
    public class MovieRatingCodesController : ApiController
    {
        private readonly VidlyDbContext _context;

        /// <summary>
        /// .....
        /// </summary>
        public MovieRatingCodesController()
        {
            _context = new VidlyDbContext();
        }
        /// <summary>
        /// Call this API method to retrieve a list of all installment codes. 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetMovieRatingCodes()
        {
            var movieRatingCodeDtos = _context.MovieRatingCodes
                .ToList()
                .Select(Mapper.Map<MovieRatingCode, MovieRatingCodeDto>);
            return Ok(movieRatingCodeDtos);
        }
        /// <summary>
        /// Call this API method to retrieve a single movie rating code.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetMovieRatingCode(int id)
        {
            var movieRatingCode = _context.MovieRatingCodes
                .SingleOrDefault(m => m.Id == id);

            if(movieRatingCode == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<MovieRatingCode, MovieRatingCodeDto>(movieRatingCode));
        }
    }
}
