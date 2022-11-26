using Application.DTOs.External;
using Application.Services;
using MediatR;

namespace Application.Requests;
public class GetBooksByNameRequestHandler : IRequestHandler<GetBooksByNameRequest,IEnumerable<GoogleBookDto>>
{
    private readonly IGoogleBooksClient _googleBooks;

    public GetBooksByNameRequestHandler(IGoogleBooksClient googleBooks)
    {
        _googleBooks = googleBooks;
    }
    public Task<IEnumerable<GoogleBookDto>> Handle(GetBooksByNameRequest request, CancellationToken cancellationToken)
    {
        return _googleBooks.GetBooksByTitle(request.SearchInput, cancellationToken);
    }
}
public class GetBooksByNameRequest : IRequest<IEnumerable<GoogleBookDto>>
{
    public string SearchInput { get; set; }
}