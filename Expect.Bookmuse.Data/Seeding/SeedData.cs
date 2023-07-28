using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Expect.Bookmuse.Data.Seeding
{
	public static class SeedData
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			var shelf1 = new Shelf()
			{
				Id = Guid.NewGuid(),
				MaxNumberOfBooks = 10
			};
			var shelf2 = new Shelf()
			{
				Id = Guid.NewGuid(),
				MaxNumberOfBooks = 100
			};

			var book = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf1.Id,
				Name = "Book1",
				Author = "Author1",
				Genres = new List<Genre> { Genre.Folklore, Genre.FanFiction, Genre.Classic},
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 100,
				NumberOfPages = 650,
				Publisher = "Publisher1",
				Volume = "tome1",
				Sells = 0
			};

			var book2 = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf1.Id,
				Name = "Book2",
				Author = "Author2",
				Genres = new List<Genre> { Genre.Biography, Genre.Detective},
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 120,
				NumberOfPages = 400,
				Publisher = "Publisher2",
				Volume = "tome1",
				Sells = 0
			};
			var book3 = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf1.Id,
				Name = "Book3",
				Author = "Author3",
				Genres = new List<Genre> { Genre.Cookbook, Genre.Essay},
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 80,
				NumberOfPages = 300,
				Publisher = "Publisher3",
				Volume = "tome1",
				Sells = 0
			};
			var book4 = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf1.Id,
				Name = "Book4",
				Author = "Author4",
				Genres = new List<Genre> { Genre.ActionAndAdventure, Genre.Dystopia},
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 150,
				NumberOfPages = 800,
				Publisher = "Publisher4",
				Volume = "tome1",
				Sells = 0
			};
			var book5 = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf2.Id,
				Name = "Book5",
				Author = "Author5",
				Genres = new List<Genre> { Genre.Horror, Genre.Detective },
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 90,
				NumberOfPages = 250,
				Publisher = "Publisher5",
				Volume = "tome1",
				Sells = 0
			};
			var book6 = new Book()
			{
				Id = Guid.NewGuid(),
				ShelfId = shelf2.Id,
				Name = "Book6",
				Author = "Author6",
				Genres = new List<Genre> { Genre.HistoricalFiction, Genre.Biography },
				ReleaseDate = DateOnly.FromDateTime(DateTime.Now),
				Price = 110,
				NumberOfPages = 500,
				Publisher = "Publisher6",
				Volume = "tome1",
				Sells = 0
			};

			modelBuilder.Entity<Shelf>().HasData(shelf1, shelf2);
			modelBuilder.Entity<Book>().HasData(book, book2, book3, book4, book5, book6);
		}
	}
}
