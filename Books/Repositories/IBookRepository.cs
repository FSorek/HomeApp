using Books.Entities;

namespace Books.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
}