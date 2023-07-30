using Expect.Bookmuse.Infrastructure.Commands.UpdateBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.BookInfo).NotEmpty().SetValidator(new BookInfoValidator());
        }
    }
}
