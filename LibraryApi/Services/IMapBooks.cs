using LibraryApi.Models;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IMapBooks
    {
        Task<GetBooksResponse> GetBooks(string genre);
    }
}