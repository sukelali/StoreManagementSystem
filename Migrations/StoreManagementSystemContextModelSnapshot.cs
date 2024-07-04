﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreManagementSystem.Data;

#nullable disable

namespace StoreManagementSystem.Migrations
{
    [DbContext(typeof(StoreManagementSystemContext))]
    partial class StoreManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoreManagementSystem.Models.ItemCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("StoreManagementSystem.Models.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5296),
                            Name = "Piece",
                            Symbol = "PCS",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5298)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5300),
                            Name = "Yards",
                            Symbol = "YDS",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5301)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5302),
                            Name = "Centimeter",
                            Symbol = "CM",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5303)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5304),
                            Name = "Milimeter",
                            Symbol = "MM",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5304)
                        },
                        new
                        {
                            Id = 5L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5306),
                            Name = "Gauss",
                            Symbol = "GS",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5306)
                        },
                        new
                        {
                            Id = 6L,
                            CreatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5307),
                            Name = "Cone",
                            Symbol = "Cone",
                            UpdatedOn = new DateTime(2024, 7, 4, 7, 28, 35, 498, DateTimeKind.Utc).AddTicks(5308)
                        });
                });

            modelBuilder.Entity("StoreManagementSystem.Models.ItemCategory", b =>
                {
                    b.HasOne("StoreManagementSystem.Models.ItemCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("StoreManagementSystem.Models.ItemCategory", b =>
                {
                    b.Navigation("ChildCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
