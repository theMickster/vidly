using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class MovieRatingCodeConfiguration : EntityTypeConfiguration<MovieRatingCode>
    {
        public MovieRatingCodeConfiguration()
        {
            ToTable("movie_rating_codes", "codes ");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("movie_rating_code_id")
                .IsRequired();

            Property(m => m.Rating)
                .HasColumnName("movie_rating_desc")
                .IsRequired();

            Property(m => m.IsActive)
                .HasColumnName("active_flag")
                .IsRequired();
        }
    }
}
