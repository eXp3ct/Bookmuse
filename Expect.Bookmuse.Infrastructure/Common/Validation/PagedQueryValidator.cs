using Expect.Bookmuse.Infrastructure.Commands.Common;
using FluentValidation;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
	public class PagedQueryValidator : AbstractValidator<PagedQuery>
	{
		public PagedQueryValidator()
		{
			RuleFor(x => x.Page).NotEmpty().GreaterThanOrEqualTo(0);
			RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
		}
	}
}
