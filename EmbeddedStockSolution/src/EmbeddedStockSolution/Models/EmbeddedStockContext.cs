using EmbeddedStockSolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmbeddedStockSolution.Models
{
    public class EmbeddedStockContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmbeddedStock;Trusted_Connection=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<CategoryComponentType> CategoryComponentTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryComponentType>()
                .HasKey(t => new { t.CategoryId, t.ComponentTypeId });

            modelBuilder.Entity<CategoryComponentType>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.CategoryComponentTypes)
                .HasForeignKey(pt => pt.CategoryId);

            modelBuilder.Entity<CategoryComponentType>()
                .HasOne(pt => pt.ComponentType)
                .WithMany(t => t.CategoryComponentTypes)
                .HasForeignKey(pt => pt.ComponentTypeId);
        }
    }

}
