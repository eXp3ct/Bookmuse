using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Domain.Interfaces
{
    public interface IOperationResult
    {
        public object? Data { get; set; }
        public bool Success { get; set; }
    }
}
