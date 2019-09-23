using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class MovieGenreCodeConfiguration : EntityTypeConfiguration<MovieGenreCode>
    {
        public MovieGenreCodeConfiguration()
        {
            ToTable("movie_genre_codes", "codes ");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("movie_genre_code_id")
                .IsRequired();

            Property(m => m.Genre)
                .HasColumnName("movie_genre_desc")
                .IsRequired();

            Property(m => m.IsActive)
                .HasColumnName("active_flag")
                .IsRequired();                       
        }
    }
}
