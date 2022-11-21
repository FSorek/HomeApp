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
            Title = f.Commerce.ProductName(),
            Description = f.Lorem.Paragraph(8),
            ImageUrl = f.Image.PicsumUrl(340,440),
            Author = f.Name.FullName()
        });
    }
    public Task<IEnumerable<Book>> GetAllAsync()
    {
        IEnumerable<Book> books = _bookFaker.Generate(10);
        return Task.FromResult(books);
    }
}