using Expect.Bookmuse.Infrastructure.Commands.BuyBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class BuyBookValidator : AbstractValidator<BuyBookQuery>
    {
        public BuyBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
