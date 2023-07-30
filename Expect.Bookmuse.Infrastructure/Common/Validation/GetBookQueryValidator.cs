using Expect.Bookmuse.Infrastructure.Commands.GetBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
