namespace Expect.Bookmuse.Domain
{
	public class OperationResult
	{
		public object? Data { get; set; }
		public bool Success { get; set; } = true;
		public DateTime DateTime { get; } = DateTime.Now;
	}
}
