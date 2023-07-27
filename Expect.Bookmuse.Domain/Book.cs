using Expect.Bookmuse.Domain.Base;
using Expect.Bookmuse.Domain.Enums;

namespace Expect.Bookmuse.Domain
{
	public class Book : EntityBase
	{
		public Guid ShelfId { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public DateOnly ReleaseDate { get; set; }
		public List<Genre> Genres { get; set; }
		public string Volume { get; set; }
		public string Publisher { get; set; }
		public int NumberOfPages { get; set; }
		public long Sells { get; set; }
		public decimal Price { get; set; }
	}
}
