using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Expect.Bookmuse.Data.Seeding;

namespace Expect.Bookmuse.Data
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public DbSet<Shelf> Shelves { get; set; }

		public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			SeedData.Seed(modelBuilder);
			base.OnModelCreating(modelBuilder);
		}
	}
}
