using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class GetListOfBooksQueryValidator : AbstractValidator<GetListOfBooksQuery>
    {
        public GetListOfBooksQueryValidator()
        {
            RuleFor(x => x.Page).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
