using Expect.Bookmuse.Domain.Interfaces;

namespace Expect.Bookmuse.Domain
{
	public class OperationResult : IOperationResult
	{
		public object? Data { get; set; }
		public bool Success { get; set; } = true;
		public DateTime DateTime { get; } = DateTime.Now;
	}

	public class OperationResultTest1
	{
		public Book Data { get; set; }
		public bool Success { get; set; }
		public DateTime DateTime { get; set; }
	}
}
