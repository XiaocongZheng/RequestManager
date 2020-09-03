using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RequestManager.Models
{
    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("RMData") { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RequestModel> Request { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<RequestModel>().ToTable("Request");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }
    }
}