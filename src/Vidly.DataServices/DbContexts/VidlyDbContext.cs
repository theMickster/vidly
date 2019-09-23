using System.Data.Entity;
using Vidly.DataServices.EntityConfigurations;
using Vidly.DataServices.Models;
using Vidly.Shared.Utilities;

namespace Vidly.DataServices.DbContexts
{
    public class VidlyDbContext : DbContext
    {
        public VidlyDbContext(): base(VidlyConnectionString.ConnectionString)
        {
        }

        public static VidlyDbContext Create()
        {
            return new VidlyDbContext();
        }
        
        public DbSet<MembershipTypeCode> MembershipTypeCodes { get; set; }
        public DbSet<MovieGenreCode> MovieGenreCodes { get; set; }
        public DbSet<MovieRatingCode> MovieRatingCodes { get; set; }
        public DbSet<InstallmentCode> InstallmentCodes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MembershipTypeCodeConfiguration());
            modelBuilder.Configurations.Add(new MovieGenreCodeConfiguration());            
            modelBuilder.Configurations.Add(new MovieRatingCodeConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MovieDetailConfiguration());
            modelBuilder.Configurations.Add(new InstallmentCodeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
