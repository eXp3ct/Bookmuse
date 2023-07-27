using AutoMapper;
using Expect.Bookmuse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Common.Mapping
{
	public class BookInfoMappingProfile : Profile
	{
        public BookInfoMappingProfile()
        {
            CreateMap<BookInfo, Book>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()));
        }
    }
}
