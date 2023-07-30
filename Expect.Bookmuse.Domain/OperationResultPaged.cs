using Expect.Bookmuse.Domain.Interfaces;

namespace Expect.Bookmuse.Domain
{
	public class OperationResultPaged : OperationResult, IOperationResultPaged
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}

	public class OperationResultTest
	{
		public List<Book> Data { get; set; }
		public int Page { get; set; }
		public int PageSize { get; set; }
		public bool Success { get; set; }
		public DateTime DateTime { get; set; }
	}
}
