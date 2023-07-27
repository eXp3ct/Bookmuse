using Expect.Bookmuse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Data.Configuration
{
	public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
	{
		public void Configure(EntityTypeBuilder<Shelf> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.MaxNumberOfBooks).IsRequired();
		}
	}
}
