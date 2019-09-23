using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.DataServices.DbContexts;

namespace VidlyConsoleApp01.Examples
{
    public class MovieExamples
    {

        public void Example01()
        {
            using (var db = new VidlyDbContext())
            {
                var result = db.Movies.Include(m => m.MovieGenreCode).ToList();

                Console.WriteLine("All movies in the database are as follows...");
                Console.WriteLine();
                foreach (var item in result)
                {
                    Console.WriteLine($"Movie Name: {item.MovieName}, Release Date: {item.ReleaseDate}, Genre: {item.MovieGenreCode.Genre}");
                }
            }
        }
        public void Example02()
        {
            using (var db = new VidlyDbContext())
            {
                var result = db.Movies.Include(m => m.MovieDetail).ToList();

                Console.WriteLine("All movies in the database with their details are as follows...");
                Console.WriteLine();
                foreach (var item in result)
                {
                    Console.WriteLine($"Movie Name: {item.MovieName}, Release Date: {item.ReleaseDate}, Runtime: {item.Runtime}, IMDB URL: {item.MovieDetail.ImdbUrl}");
                }
            }
        }

    }
}
