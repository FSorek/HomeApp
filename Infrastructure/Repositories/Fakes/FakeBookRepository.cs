using Bogus;
using BookRecommendations.Entities;
using BookRecommendations.Repositories;

namespace Infrastructure.Repositories;

public class FakeBookRepository : IBookRepository
{
    private Faker<BookEntry> _bookFaker;

    public FakeBookRepository()
    {
        _bookFaker = new Faker<BookEntry>().CustomInstantiator(f => new BookEntry()
        {
            MyOpinion = f.Lorem.Paragraph(8),
            MyRating = f.Random.Double(1d, 5d)
        });
    }

    public Task<IEnumerable<BookEntry>> GetAllAsync()
    {
        IEnumerable<BookEntry> books = _bookFaker.Generate(10);
        return Task.FromResult(books);
    }
}