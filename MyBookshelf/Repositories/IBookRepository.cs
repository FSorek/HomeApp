using BookRecommendations.Entities;

namespace BookRecommendations.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<BookEntry>> GetAllAsync();
}