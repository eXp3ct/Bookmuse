using Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties;
using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class GetListOfBooksByPropertiesQueryValidator : AbstractValidator<GetBooksByPropertiesQuery>
    {
        public GetListOfBooksByPropertiesQueryValidator()
        {
            RuleFor(x => x.Page).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
