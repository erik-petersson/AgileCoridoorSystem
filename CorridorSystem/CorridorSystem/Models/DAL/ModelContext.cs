using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorridorSystem.Models.DAL
{
    public class ModelContext : IdentityDbContext<IdentityUser>
    {

        public ModelContext() : base("ModelContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<CorrUser> MyUsers { get; set; }
        public DbSet<RemovedUsers> RmUsers { get; set; }
        public DbSet<scheduleModel> schedule { get; set; }
        public DbSet<eventModel> events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}