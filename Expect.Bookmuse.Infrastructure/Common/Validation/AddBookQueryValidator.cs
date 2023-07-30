using Expect.Bookmuse.Infrastructure.Commands.AddBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class AddBookQueryValidator : AbstractValidator<AddBookQuery>
    {
        public AddBookQueryValidator()
        {
            RuleFor(x => x.BookInfo).NotNull().SetValidator(new BookInfoValidator());
        }
    }
}
