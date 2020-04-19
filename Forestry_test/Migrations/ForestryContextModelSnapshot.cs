﻿// <auto-generated />
using System;
using Forestry_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forestry_test.Migrations
{
    [DbContext(typeof(ForestryContext))]
    partial class ForestryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forestry_test.Models.Appointment", b =>
                {
                    b.Property<int>("PointID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PointName");

                    b.HasKey("PointID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Forestry_test.Models.Forest", b =>
                {
                    b.Property<int>("ForestID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarID");

                    b.Property<int?>("LghtProdID");

                    b.Property<int?>("LocID");

                    b.Property<int?>("PointID");

                    b.Property<int>("Quarters");

                    b.Property<int?>("SortID");

                    b.HasKey("ForestID");

                    b.HasIndex("CarID");

                    b.HasIndex("LghtProdID");

                    b.HasIndex("LocID");

                    b.HasIndex("PointID");

                    b.HasIndex("SortID");

                    b.ToTable("Forests");
                });

            modelBuilder.Entity("Forestry_test.Models.Location", b =>
                {
                    b.Property<int>("LocID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Loc");

                    b.HasKey("LocID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Forestry_test.Models.Mazist", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("FIO")
                        .HasMaxLength(50);

                    b.HasKey("CarID");

                    b.ToTable("Mazists");
                });

            modelBuilder.Entity("Forestry_test.Models.Product", b =>
                {
                    b.Property<int>("ProdID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lght");

                    b.Property<int?>("LocID");

                    b.Property<int>("Quarters");

                    b.Property<int?>("SortID");

                    b.Property<int>("Volume");

                    b.HasKey("ProdID");

                    b.HasIndex("LocID");

                    b.HasIndex("SortID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Forestry_test.Models.Sort", b =>
                {
                    b.Property<int>("SortID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SortD");

                    b.HasKey("SortID");

                    b.ToTable("Sorts");
                });

            modelBuilder.Entity("Forestry_test.Models.Forest", b =>
                {
                    b.HasOne("Forestry_test.Models.Mazist", "FIO")
                        .WithMany("Forests")
                        .HasForeignKey("CarID");

                    b.HasOne("Forestry_test.Models.Product", "Lght")
                        .WithMany("Forests")
                        .HasForeignKey("LghtProdID");

                    b.HasOne("Forestry_test.Models.Location", "Loc")
                        .WithMany()
                        .HasForeignKey("LocID");

                    b.HasOne("Forestry_test.Models.Appointment", "PointName")
                        .WithMany("Forests")
                        .HasForeignKey("PointID");

                    b.HasOne("Forestry_test.Models.Sort", "SortD")
                        .WithMany()
                        .HasForeignKey("SortID");
                });

            modelBuilder.Entity("Forestry_test.Models.Product", b =>
                {
                    b.HasOne("Forestry_test.Models.Location", "Loc")
                        .WithMany("Product")
                        .HasForeignKey("LocID");

                    b.HasOne("Forestry_test.Models.Sort", "Sorte")
                        .WithMany("Product")
                        .HasForeignKey("SortID");
                });
#pragma warning restore 612, 618
        }
    }
}
