namespace Expect.Bookmuse.Domain
{
	public class OperationResultPaged : OperationResult
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
