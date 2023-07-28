﻿// <auto-generated />
using System;
using Expect.Bookmuse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Expect.Bookmuse.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Expect.Bookmuse.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int[]>("Genres")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Publisher")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<long>("Sells")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ShelfId")
                        .HasColumnType("uuid");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed047556-be86-4ee9-b111-7889f7a59db9"),
                            Author = "Author1",
                            Genres = new[] { 13, 12, 10 },
                            Name = "Book1",
                            NumberOfPages = 650,
                            Price = 100m,
                            Publisher = "Publisher1",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"),
                            Volume = "tome1"
                        },
                        new
                        {
                            Id = new Guid("2a8b311d-a5fd-4e2c-9a7c-fee27eccf869"),
                            Author = "Author2",
                            Genres = new[] { 15, 1 },
                            Name = "Book2",
                            NumberOfPages = 400,
                            Price = 120m,
                            Publisher = "Publisher2",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"),
                            Volume = "tome1"
                        },
                        new
                        {
                            Id = new Guid("f3110eff-ba3a-421b-b23d-5e2cd642daf9"),
                            Author = "Author3",
                            Genres = new[] { 25, 17 },
                            Name = "Book3",
                            NumberOfPages = 300,
                            Price = 80m,
                            Publisher = "Publisher3",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"),
                            Volume = "tome1"
                        },
                        new
                        {
                            Id = new Guid("5b96ca09-0242-45cf-9150-067fc34e7f34"),
                            Author = "Author4",
                            Genres = new[] { 0, 4 },
                            Name = "Book4",
                            NumberOfPages = 800,
                            Price = 150m,
                            Publisher = "Publisher4",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"),
                            Volume = "tome1"
                        },
                        new
                        {
                            Id = new Guid("716f5df8-0ae8-404b-99c2-a07ff5e188b6"),
                            Author = "Author5",
                            Genres = new[] { 9, 1 },
                            Name = "Book5",
                            NumberOfPages = 250,
                            Price = 90m,
                            Publisher = "Publisher5",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"),
                            Volume = "tome1"
                        },
                        new
                        {
                            Id = new Guid("843c82ff-02c2-4219-87bd-cfda19a31440"),
                            Author = "Author6",
                            Genres = new[] { 3, 15 },
                            Name = "Book6",
                            NumberOfPages = 500,
                            Price = 110m,
                            Publisher = "Publisher6",
                            ReleaseDate = new DateOnly(2023, 7, 28),
                            Sells = 0L,
                            ShelfId = new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"),
                            Volume = "tome1"
                        });
                });

            modelBuilder.Entity("Expect.Bookmuse.Domain.Shelf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("MaxNumberOfBooks")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Shelves");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5569545c-f7f8-427e-874a-80c8b275cde2"),
                            MaxNumberOfBooks = 10
                        },
                        new
                        {
                            Id = new Guid("406316a4-7164-4b35-ab11-5d8bc2d4af8d"),
                            MaxNumberOfBooks = 100
                        });
                });

            modelBuilder.Entity("Expect.Bookmuse.Domain.Book", b =>
                {
                    b.HasOne("Expect.Bookmuse.Domain.Shelf", null)
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
