using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Builders
{
    public class OperationResultBuilder : IOperationResultBuilder
    {
        private OperationResult _result = new();

        public IOperationResultBuilder AddData(object? data)
        {
            _result.Data = data;
            return this;
        }

        public IOperationResult Build()
        {
            return _result;
        }

        public IOperationResultPaged BuildPaged(int page, int pageSize)
        {
            return new OperationResultPaged { Data = _result.Data, Page = page, PageSize = pageSize, Success = _result.Success };
        }

        public IOperationResultBuilder IsFailure()
        {
            _result.Success = false;
            return this;
        }
    }
}
