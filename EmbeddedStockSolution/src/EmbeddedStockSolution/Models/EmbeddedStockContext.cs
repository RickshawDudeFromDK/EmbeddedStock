using EmbeddedStockSolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmbeddedStock.Models
{
    public class EmbeddedStockContext : DbContext
    {
        public EmbeddedStockContext(DbContextOptions<EmbeddedStockContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }



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
