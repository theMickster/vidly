using System.Data.Entity.ModelConfiguration;
using Vidly.DataServices.Models;

namespace Vidly.DataServices.EntityConfigurations
{
    public class MovieDetailConfiguration : EntityTypeConfiguration<MovieDetail>
    {
        public MovieDetailConfiguration()
        {
            ToTable("movie_details");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("movie_id")
                .IsRequired();

            Property(m => m.ImdbUrl)
                .HasColumnName("imdb_url");

            Property(m => m.Summary)
                .HasColumnName("summary");

            Property(m => m.StoryLine)
                .HasColumnName("story_line");

            Property(m => m.IsActive)
                .HasColumnName("active_flag")
                .IsRequired();

            Property(m => m.InstallmentId)
                .HasColumnName("installment_id");

            /*********************************************************************************
             * Configuring nullable foreign keys that don't follow the naming standard
             ********************************************************************************/
            HasOptional(m => m.InstallmentCode)
                .WithMany(m => m.MovieDetails)
                .HasForeignKey(m => m.InstallmentId);

        }
    }
}
