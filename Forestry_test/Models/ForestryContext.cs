using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forestry_test.Models
{
    public class ForestryContext:DbContext
    {
        public ForestryContext(DbContextOptions<ForestryContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Mazist> Mazists { get; set; }
        public DbSet<Sort> Sorts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Forest> Forests { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Forest>().Ignore(c => c.Lght);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
