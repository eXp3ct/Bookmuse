using Expect.Bookmuse.Domain;
using FluentValidation;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
	public class ShelfValidator : AbstractValidator<Shelf>
	{
		public ShelfValidator()
		{
			RuleFor(x => x.MaxNumberOfBooks).NotEmpty().GreaterThan(0);
		}
	}
}
