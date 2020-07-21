using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class BooksEFMap : IMapBooks
    {
        LibraryDataContext Context;

        IMapper BooksMapper;
        MapperConfiguration MapperConfig;

        public BooksEFMap(LibraryDataContext context, MapperConfiguration mapperConfiguration, IMapper mapper)
        {
            Context = context;
            BooksMapper = mapper;
            MapperConfig = mapperConfiguration;
        }

        public async Task<GetBooksResponse> GetBooks(string genre)
        {
            var books = Context.Books
                .Where(b => b.InStock)
                .ProjectTo<GetBooksResponseItem>(MapperConfig);


            if (genre != null)
            {
                books = books.Where(b => b.Genre == genre);
            }

            var booksList = await books.ToListAsync();
            return new GetBooksResponse
            {
                Books = booksList,
                GenreFilter = genre,
                NumberOfBooks = booksList.Count
            };
        }
    }
}
