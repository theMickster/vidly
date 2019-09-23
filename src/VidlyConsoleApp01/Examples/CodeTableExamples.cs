using System;
using System.Linq;
using Vidly.DataServices.DbContexts;

namespace VidlyConsoleApp01.Examples
{
    public class CodeTableExamples
    {

        public void Example01()
        {
            using (var db = new VidlyDbContext())
            {
                var membershipTypes = db.MembershipTypeCodes.ToList();

                Console.WriteLine("Membership Types...");
                foreach (var m in membershipTypes)
                {
                    Console.WriteLine($"MembershipTypeId: {m.MembershipTypeCodeId}, MembershipTypeName: {m.MembershipTypeDesc}");
                }

            }
        }

        public void Example02()
        {
            using (var db = new VidlyDbContext())
            {
                var genres = db.MovieGenreCodes.ToList();
                Console.WriteLine("Genres Types (from codes schema)...");

                foreach (var g in genres)
                {
                    Console.WriteLine($"Genre Id: {g.Id}, Genre: {g.Genre}, Is Active? {g.IsActive}");
                }

                var ratings = db.MovieRatingCodes.ToList();
                Console.WriteLine("Rating Types (from codes schema)...");
                foreach (var r in ratings)
                {
                    Console.WriteLine($"Rating Id: {r.Id}, Rating: {r.Rating}, Is Active? {r.IsActive}");
                }
               
            }

        }
    }
}
