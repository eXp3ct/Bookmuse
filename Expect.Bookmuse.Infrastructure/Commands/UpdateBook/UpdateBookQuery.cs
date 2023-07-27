using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Commands.UpdateBook
{
	public class UpdateBookQuery : IdQuery
	{
		public BookInfo? BookInfo { get; set; }
	}
}
