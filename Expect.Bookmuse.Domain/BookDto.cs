namespace Expect.Bookmuse.Domain
{
	public class BookDto
	{
		public Guid Id { get; set; }
		public Guid ShelfId { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public DateOnly ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}
