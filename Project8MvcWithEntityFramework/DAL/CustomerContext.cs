using Project8MvcWithEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Project8MvcWithEntityFramework.DAL
{
    public class CustomerContext:DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public new void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}