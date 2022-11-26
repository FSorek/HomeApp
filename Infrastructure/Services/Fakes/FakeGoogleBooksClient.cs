using Application.DTOs.External;
using Application.Services;
using Bogus;

namespace Infrastructure.Services;

public class FakeGoogleBooksClient : IGoogleBooksClient
{
    private Faker<GoogleBookDto> _googleBookFaker;

    public FakeGoogleBooksClient()
    {
        _googleBookFaker = new Faker<GoogleBookDto>().CustomInstantiator(f => new GoogleBookDto()
        {
            Id = f.Database.Random.Hash(length: 10),
            Title = f.Commerce.ProductName(),
            Subtitle = f.Commerce.ProductAdjective(),
            Description = f.Lorem.Paragraphs(5, 20),
            Publisher = f.Company.CompanyName(),
            Authors = f.Make(f.Random.Int(1,3), () => f.Name.FullName()).ToArray(),
            AverageRating = f.Random.Double(1d, 5d),
            ThumbnailUrl = f.Image.PlaceholderUrl(300, 400)
        });
    }
    public Task<GoogleBookDto> GetBook(string id)
    {

        var fakeBook = _googleBookFaker.Generate();
        return Task.FromResult(fakeBook);
    }

    public Task<IEnumerable<GoogleBookDto>> GetBooksByTitle(string inputTitle, CancellationToken token)
    {
        IEnumerable<GoogleBookDto> books = _googleBookFaker.Generate(10);
        return Task.FromResult(books);
    }
}