using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vidly.DataServices.EntityConfigurations;
using Vidly.DataServices.Models;
using Vidly.DataServices.Services;
using Vidly.Shared.Utilities;

namespace Vidly.DataServices.DbContexts
{
    public class VidlyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public VidlyIdentityDbContext() : base(VidlyConnectionString.ConnectionString)
        {
        }

        public static VidlyIdentityDbContext Create()
        {
            return new VidlyIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
