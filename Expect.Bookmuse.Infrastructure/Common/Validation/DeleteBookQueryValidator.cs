using Expect.Bookmuse.Infrastructure.Commands.DeleteBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Validation
{
    public class DeleteBookQueryValidator : AbstractValidator<DeleteBookQuery>
    {
        public DeleteBookQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
