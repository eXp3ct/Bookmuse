using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Domain.Interfaces
{
    public interface IOperationResultPaged : IOperationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
