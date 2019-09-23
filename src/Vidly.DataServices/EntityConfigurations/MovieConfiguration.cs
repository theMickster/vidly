using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id)
                .HasColumnName("movie_id")
                .IsRequired();

            Property(m => m.MovieName)
                .HasColumnName("movie_name")
                .IsRequired();

            Property(m => m.ReleaseDate)
                .HasColumnName("release_date");

            Property(m => m.MovieDescription)
                .HasColumnName("movie_desc");

            Property(m => m.MoviePlotSummary)
                .HasColumnName("movie_plot_summary");

            Property(m => m.MovieRatingCodeId)
                .HasColumnName("movie_rating_code_id");

            Property(m => m.GenreId)
                .HasColumnName("movie_genre_code_id");

            /*********************************************************************************
             * Configuring nullable foreign keys that don't follow the naming standard
             ********************************************************************************/
            HasOptional(m => m.MovieRatingCode)
            .WithMany(t => t.Movies)
            .HasForeignKey(w => w.MovieRatingCodeId);

            HasOptional(m => m.MovieGenreCode)
            .WithMany(t => t.Movies)
            .HasForeignKey(w => w.GenreId);

            HasRequired(m => m.MovieDetail)
                .WithRequiredPrincipal(m => m.Movie);

        }
    }
}
