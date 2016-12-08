using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EmbeddedStockSolution.Models;

namespace EmbeddedStockSolution.Migrations
{
    [DbContext(typeof(EmbeddedStockContext))]
    [Migration("20161207052704_firstt")]
    partial class firstt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmbeddedStockSolution.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EmbeddedStockSolution.Models.CategoryComponentType", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("ComponentTypeId");

                    b.HasKey("CategoryId", "ComponentTypeId");

                    b.HasIndex("ComponentTypeId");

                    b.ToTable("CategoryComponentTypes");
                });

            modelBuilder.Entity("EmbeddedStockSolution.Models.Component", b =>
                {
                    b.Property<int>("ComponentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComponentNumber");

                    b.Property<int>("ComponentTypeId");

                    b.Property<string>("SearchTerm");

                    b.Property<string>("SerialNo");

                    b.HasKey("ComponentId");

                    b.HasIndex("ComponentTypeId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("EmbeddedStockSolution.Models.ComponentType", b =>
                {
                    b.Property<int>("ComponentTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComponentInfo");

                    b.Property<string>("ComponentName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location");

                    b.Property<string>("Manufacturer");

                    b.HasKey("ComponentTypeId");

                    b.ToTable("ComponentTypes");
                });

            modelBuilder.Entity("EmbeddedStockSolution.Models.CategoryComponentType", b =>
                {
                    b.HasOne("EmbeddedStockSolution.Models.Category", "Category")
                        .WithMany("CategoryComponentTypes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmbeddedStockSolution.Models.ComponentType", "ComponentType")
                        .WithMany("CategoryComponentTypes")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmbeddedStockSolution.Models.Component", b =>
                {
                    b.HasOne("EmbeddedStockSolution.Models.ComponentType")
                        .WithMany("Components")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
