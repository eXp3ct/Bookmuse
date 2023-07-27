namespace Expect.Bookmuse.Domain
{
	public class OperationResultPaged : OperationResult
	{
		public int Index { get; set; }
		public int PageSize { get; set; }
	}
}
