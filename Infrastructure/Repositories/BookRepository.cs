using Books.Entities;
using Books.Repositories;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync()
    {
        IEnumerable<Book> books = new[]
        {
            new Book()
            {
                Title = "Test Book 1",
                Description = "My favourite book 1",
                ImageUrl = @"https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/c_limit,w_695/v1625001870/geyxcm0dflkhmynemitv.png"
            }
        };
        return Task.FromResult(books);
    }
}