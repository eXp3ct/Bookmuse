using Expect.Bookmuse.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Domain
{
	public class Shelf : EntityBase
	{
		public int MaxNumberOfBooks { get; set; }
	}
}
