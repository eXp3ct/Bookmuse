using AutoMapper;
using Expect.Bookmuse.Domain;

namespace Expect.Bookmuse.Infrastructure.Common.Mapping
{
	public class BookDtoMappingProfile : Profile
	{
		public BookDtoMappingProfile()
		{
			CreateMap<Book, BookDto>()
				.ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
				.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
				.ForMember(x => x.ShelfId, opt => opt.MapFrom(x => x.ShelfId))
				.ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author))
				.ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
				.ForMember(x => x.ReleaseDate, opt => opt.MapFrom(x => x.ReleaseDate));
		}
	}
}
