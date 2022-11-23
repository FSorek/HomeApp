using Application.DTOs.External;
using Application.Services;
using MediatR;

namespace Application.Requests;
public class GetGoogleBookRequestHandler : IRequestHandler<GetGoogleBookRequest, GoogleBookDto>
{
    private readonly IGoogleBooksClient _googleBooks;

    public GetGoogleBookRequestHandler(IGoogleBooksClient googleBooks)
    {
        _googleBooks = googleBooks;
    }
    public async Task<GoogleBookDto> Handle(GetGoogleBookRequest request, CancellationToken cancellationToken)
    {
        var book = await _googleBooks.GetBook(request.Id);
        return book;
    }
}

public class GetGoogleBookRequest : IRequest<GoogleBookDto>
{
    public GetGoogleBookRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}