using Bogus;
using Books.Entities;
using Books.Repositories;

namespace Infrastructure.Repositories;

public class FakeBookRepository : IBookRepository
{
    private Faker<Book> _bookFaker;

    public FakeBookRepository()
    {
        _bookFaker = new Faker<Book>().CustomInstantiator(f => new Book()
        {
            MyOpinion = f.Lorem.Paragraph(8),
            MyRating = f.Random.Double(1d, 5d)
        });
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        IEnumerable<Book> books = _bookFaker.Generate(10);
        return Task.FromResult(books);
    }
}