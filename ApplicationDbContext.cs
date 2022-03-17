using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EntityFrameworkCoreExample
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle();
            base.OnConfiguring(optionsBuilder); 
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mySchema");

            MapEntities(modelBuilder);
        }

        private void MapEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityExampleMap());
        }

        public DbSet<EntityExample> EntityExamples { get; set; }
    }
}
