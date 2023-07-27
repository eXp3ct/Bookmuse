using Expect.Bookmuse.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Interfaces
{
	public interface IAppDbContext 
	{
		public DbSet<Shelf> Shelves { get; }
		public DbSet<Book> Books { get; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
