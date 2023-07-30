using Expect.Bookmuse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Builders
{
    public interface IOperationResultBuilder
    {
        public IOperationResult Build();
        public IOperationResultPaged BuildPaged(int page, int pageSize);
        public IOperationResultBuilder AddData(object? data);
        public IOperationResultBuilder IsFailure();
    }
}
