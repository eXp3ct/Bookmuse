using Expect.Bookmuse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Bookmuse.Data.Configuration
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
			builder.Property(x => x.Author).HasMaxLength(255).IsRequired(false);
			builder.Property(x => x.Publisher).HasMaxLength(255).IsRequired(false);
			builder.HasOne<Shelf>().WithMany().HasForeignKey(x => x.ShelfId);
		}
	}
}
