using Expect.Bookmuse.Domain.Enums;

namespace Expect.Bookmuse.Domain
{
	public class BookInfo
	{
		public string? Name { get; set; }
		public DateOnly? ReleaseDate { get; set; }
		public string? Author { get; set; }
		public List<Genre>? Genres { get; set; }
		public string? Volume { get; set; }
		public string? Publisher { get; set; }
		public int? NumberOfPages { get; set; }
		public decimal? Price { get; set; }
	}
}
