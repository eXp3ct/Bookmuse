using Expect.Bookmuse.Domain.Base;
using Expect.Bookmuse.Domain.Interfaces;
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
