using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CorridorSystem.Models.DAL
{
    public class ModelContext : DbContext
    {

        public ModelContext() : base("ModelContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RemovedUsers> RmUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}