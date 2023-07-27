using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Enums;
using FluentValidation;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
	public class BookValidator : AbstractValidator<Book>
	{
		public BookValidator()
		{
			RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(255);
			RuleFor(x => x.Author).MaximumLength(255);
			RuleFor(x => x.Publisher).MaximumLength(255);
			RuleFor(x => x.Genres).NotNull().Must(ContainOnlyValidGenres).WithMessage("Invalid genre found in the list");
			RuleFor(x => x.Genres).Must(HaveMaximumFiveGenres).WithMessage("A book cannot have more than 5 genres");
			RuleFor(x => x).Custom(ValidateFolkloreBook);
		}

		private bool ContainOnlyValidGenres(List<Genre> genres)
		{
			return genres != null && genres.All(g => Enum.IsDefined(typeof(Genre), g));
		}

		private bool HaveMaximumFiveGenres(List<Genre> genres)
		{
			return genres.Count <= 5;
		}

		private void ValidateFolkloreBook(Book book, ValidationContext<Book> context)
		{
			if (book.Genres.Contains(Genre.Folklore) && (!string.IsNullOrEmpty(book.Author)) && (!string.IsNullOrEmpty(book.Publisher)))
			{
				context.AddFailure("Folklore books cannot have an author or publisher");
			}
		}
	}
}
