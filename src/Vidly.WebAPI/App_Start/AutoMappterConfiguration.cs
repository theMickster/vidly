using AutoMapper;
using Vidly.WebAPI.Dtos;
using Vidly.DataServices.Models;

namespace Vidly.WebAPI
{
    public static class AutoMappterConfiguration
    {
        public static void Initalize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Customer, CustomerDto>().ReverseMap();
                config.CreateMap<Movie, MovieDto>().ReverseMap();
                config.CreateMap<MovieDetail, MovieDetailDto>().ReverseMap();
                config.CreateMap<MembershipTypeCode, MembershipTypeCodeDto>().ReverseMap();
                config.CreateMap<InstallmentCode, InstallmentCodeDto>().ReverseMap();
                config.CreateMap<MovieRatingCode, MovieRatingCodeDto>().ReverseMap();
                config.CreateMap<MovieGenreCode, MovieGenreCodeDto>().ReverseMap();
            });
            
        }
    }
}