using Application.DTOs.External;
using Application.Services;
using BookRecommendations.ValueObjects;
using MediatR;

namespace Application.Requests;
public class GetBookDetailsRequestHandler : IRequestHandler<GetBookDetailsRequest, BookDetails>
{
    private readonly IGoogleBooksClient _googleBooks;

    public GetBookDetailsRequestHandler(IGoogleBooksClient googleBooks)
    {
        _googleBooks = googleBooks;
    }
    public async Task<BookDetails> Handle(GetBookDetailsRequest detailsRequest, CancellationToken cancellationToken)
    {
        var book = await _googleBooks.GetBook(detailsRequest.Id);
        var bookDetails = new BookDetails()
        {
            Title = book.Title,
            Subtitle = book.Subtitle,
            Description = book.Description,
            Publisher = book.Publisher,
            Authors = book.Authors,
            AverageRating = book.AverageRating ?? 0,
            ThumbnailUrl = book.ThumbnailUrl
        };
        return bookDetails;
    }
}

public class GetBookDetailsRequest : IRequest<BookDetails>
{
    public GetBookDetailsRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}